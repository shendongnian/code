    using System.ComponentModel.DataAnnotations;
    namespace Models
    {
        public class MyUploadModel
        {
            [Required]
            public HttpPostedFileBase File { get; set; }
            [Required] 
            public string CustomerName { get; set; }
        }
    } 
