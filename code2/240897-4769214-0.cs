    [MetadataType(typeof(Post_Validation))]
    public class Post
    {
        public int CategoryId { get; set; }
    }
    class Post_Validation
    {
        [Required(ErrorMessage = "Please select a Category")]
        public int CategoryId { get; set; }
    }
    public class AddPostViewModel
    {
        public IEnumerable<SelectListItem> Categories { get; set; }
        public Post Post { get; set; }
    }
