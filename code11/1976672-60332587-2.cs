    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<int> SelectedTags { get; set; } =  new List<int>{  2, 3 };
        [BindProperty]
        public List<Tag> Tags { get; set; }
        public void OnGet()
        {
            Tags = new List<Tag> {
        new Tag { Id = 1, Value="Mike" },
        new Tag { Id = 2, Value="Pete" },
        new Tag { Id = 3, Value="Katy" },
        new Tag { Id = 4, Value="Carl" } };
        }
    }
