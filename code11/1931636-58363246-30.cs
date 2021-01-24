    using System;    
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    namespace TestError.Controllers
    {
        [AllowAnonymous]
        public class HomeController : Controller
        {
            public HomeController() { }
            [HttpGet]
            public ViewResult Home() => View("Home");
            [HttpGet]
            public ViewResult Bogus() => throw new Exception("Bogus error");
            [HttpGet]
            public ViewResult Error() => View("Error");
            [HttpGet]
            public ViewResult PageNotFound() => View("PageNotFound");
        }
    }
