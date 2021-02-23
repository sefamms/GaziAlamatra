using AlamatraWEBUI.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AlamatraWEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailsender;

        public HomeController(ILogger<HomeController> logger,IEmailSender emailsender)
        {
            _logger = logger;
            this._emailsender = emailsender;
        }
            
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Ekibimiz()
        {
            return View();
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ContactEmail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ContactEmail(Contact contact)
        {
            var msg = contact.Name + " " + contact.Message;
            await _emailsender.SendEmailAsync(contact.Email, contact.Subject, msg);
            ViewBag.ConfirmMsg = "Thanks for Your Mail";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
