    public class PostIndexModel
    {
        public int PostId { get; set; }
        [Display(Name = "Post Name")]
        public string PostName { get; set; }
        [Display(Name = "Post Creator")]
        public string UserName { get; set; }
    }
