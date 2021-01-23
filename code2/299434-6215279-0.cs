    public class CustomJsonResult
    {
        public bool Success { get; set; }
        public ErrorType[] Errors { get; set; }
    }
    public class ErrorType
    {
         public string UserName {get;set;}
         public string EmailAddress {get;set;}
    }
