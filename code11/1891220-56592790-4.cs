    public class UserViewModel
    {
            [Required(ErrorMessage = "Please select a file.")]
            [DataType(DataType.Upload)]
            [MaxFileSize(5* 1024 * 1024)]
            [AllowedExtensions(new string[] { ".jpg", ".png" })]
            public IFormFile Photo { get; set; }
     }
