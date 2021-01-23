    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    
        namespace ZZZZZ
        {
            public class HomeController : Controller
            {
                public ActionResult Index()
                {
        
                    List<object[]> list = new List<object[]> { new object[] { "test1", DateTime.Now, -12.3 } };
        
                    return View(list);
                }
        
        
            }
        
        }
