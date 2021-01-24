    public class IndexModel : PageModel
    {
        public string IsValid { get; set; }
    
        [BindProperty(SupportsGet=true)]
        public Query query { get; set; }
    
        public void OnGet()
        {
           
        }
    
        public class Query
        {
            public int? Page { get; set; }
        }
    } 
