    using MyExample.Models
    using System.Net.Http;
    using System;
    namespace MyExample.Controllers
    {
        public class LoginController : Controller
        {
          public ActionResult Login()
          {
           return View(new LoginRequestModel());
          }
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Authenticate(LoginRequestModel loginRequest)
         {
           //Apply your authentication logic here
           bool result = someMethodToAuthenticate(loginRequest)
            if(result==true)
             {
              //Setup your session variables here
              Session["UserName"] = loginRequest.UserName;
              Session["TimeLoggedIn"] = DateTime.Now;
              return RedirectToAction("View Where You Want To Redirect", "Controller Where the View is");
             }
            else
             {
               ViewBag.setError = "Invalid login credentials supplied";
               return View("InvalidLogin");
             }
          }
       }
    }
