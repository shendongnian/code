    public class Groups
    {
        [Required(ErrorMessage = "Please enter a paygroup.")]
        [Remote("DoesPaygroupExist", "UpdateFiles", HttpMethod = "POST", ErrorMessage = "Paygroup already exists!")]
        public string PayGroup { get; set; }
        public List<UploadFiles> files {get; set;}
    }
    public class UploadFiles
    {
        public string Paygroup { get; set; }
        public string DateAdded { get; set; }
        
    
    }
