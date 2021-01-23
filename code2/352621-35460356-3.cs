    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    namespace MessagingModule.Controllers
    {
        public class MessagingController : Controller
        {
            //
            // GET: /Messaging/
    
            public ActionResult Index()
            {
              var appName = Session["appName"]; // Get some value from another module
                return Content("Yep Messaging module @"+ appName);
            }
    
        }
    }
