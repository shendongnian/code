    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    
    namespace RazorPagesIntro.Pages
    {
        public class IndexModel2 : PageModel
        {
            [BindProperty]
            public string Label { get; set; }
    
            public void OnGet()
            {
                if (id == Guid.Empty) {
                    Label = "Create"; 
                } else {
                    Label = "Update";
                }
            }
        }
    }
