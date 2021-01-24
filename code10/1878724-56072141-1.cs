    public class TestModel : PageModel
    {
        [BindProperty]
        public List<PersonViewModel> People { get; set; }
        [BindProperty]
        public List<IFormFile> FileLists { get; set; }
        
        public void OnGet()
        {
        }
        public void OnPost()
        {
            for (int i = 0; i < People.Count; i++)
            {
                People[i].Photo = FileLists[i];
            }
            //var formFile = HttpContext.Request.Form.Files;
            // Do something with People property
        }
    }
