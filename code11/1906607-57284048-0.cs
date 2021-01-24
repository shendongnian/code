    public class RadioCheckedModel : PageModel
    {
        public string District { get; set; }
        public void OnGet()
        {
            District = "Apple";
        }
    }
