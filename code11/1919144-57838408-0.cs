    public class SillyViewModel
    {
        [FromRoute]
        public int? Page { get; set; }
    
        [FromQuery(Name = "Page")]
        public int? _Page
        {
            get
            {
                return Page;
            }
            set
            {
                Page = value;
            }
        }
    
        public string Name { get; set; }
        // Some more properties
    }
