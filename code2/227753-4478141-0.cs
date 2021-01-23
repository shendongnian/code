    public class LoginInput {
       
       [Required]
       public string Username { get; set; }
       
       [Required]
       public string Password { get; set; }
    } 
    
    public class LoginResult {
       public bool Success { get; internal set; }
       public string Error { get; internal set; }
    }
