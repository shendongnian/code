    public class SomethingRequest
    {
        [Required(ErrorMessage = "Something is required, check your data")]
        public SomethingModel Something { get; set; }
    
        [Required(ErrorMessage = "Token is required!")]
        public string Token { get; set; }
    }
