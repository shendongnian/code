    using System;
    using System.Collections.Generic;
    /* this is the key */
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    
    namespace MyWebApp
    {
        public class MyPageModel : PageModel
        {
            [BindProperty(SupportsGet = true)]
            public bool CreateCourses { get; set; }
            public void OnGet()
            {
                /* set the property to use on the page */
                this.CreateCourses = User.FindAll("UserRoutes")
                    .Any(claim => claim.Value == "courses/create")
            }
        }
    }
