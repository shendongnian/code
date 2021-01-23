    public class MyCustomUserNamePasswordValidator : UserNamePasswordValidator
    {
       public override void Validate(string userName, string password)
       {
         if(userName != "foo" && password != "bar") 
         {
            throw new SecurityTokenValidationException("Invalid user");
         }
       }
    }
