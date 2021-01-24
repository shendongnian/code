    public class MovieVM
    {
        public string Title { get; set; }
        [Display(Name = "Upload Image")]
        public HttpPostedFileBase Image { get; set; }
    }
