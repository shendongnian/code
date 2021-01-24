    public class Draft
    {
        public int Id { get; set; }
       
        public string Reference { get; set; }
    
    }
    
    [BindProperty]
    public Draft Draft { get; set; }
    [BindProperty, PageRemote(ErrorMessage = "Invalid data", AdditionalFields = "__RequestVerificationToken", HttpMethod = "post", PageHandler = "CheckReference")]
    public string Reference {get;set;}
    public JsonResult OnPostCheckReference()
    {            
        var valid = !Reference.Contains("12345");
        return new JsonResult(valid);
    }
