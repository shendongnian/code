    public class CreateModel : PageModel
    {
        [BindProperty]
        public List<MyRows> rows { get; set; }
        public void OnGet()
        {
            rows = new List<MyRows>()
            {
                new MyRows{ Name="name1"},
                new MyRows{ Name="name2"}
            };
        }
        
        public async Task OnPostAsync()
        {
            var list = rows;
        }
        public class MyRows
        {
            public string Name { get; set; }
        }
    }
