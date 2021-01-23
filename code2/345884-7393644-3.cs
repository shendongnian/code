    public class BlogContentModel 
    {
        [Required]
        [Display(Name = "Post Title")]
        public string Title { get; set; }
    
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Post Content")]
        public string Content { get; set; }
    
        public MarkdownTextAreaModel MarkDown { get; set; }
    }
