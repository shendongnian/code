    public class QuestionViewModel
    {
        [Required]
        public string Question { get; set; }
        public HttpPostedFileBase Attachment { get; set; }
    }
