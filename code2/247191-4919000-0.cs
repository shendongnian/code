    public class MyViewModel
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
    public class MainViewModel
    {
        public MyViewModel Obj { get; set; }
    }
