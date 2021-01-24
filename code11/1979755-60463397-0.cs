    public class LoginModel
    {
       public string Email {get;set;}
       public string Password {get;set}
    }
    
    [HttpPost]
    [Route("login")
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
      // your code
    }
