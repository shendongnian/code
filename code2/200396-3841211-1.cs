    public static class Register
    {
         public static RegisterModel RegisterUser()
         {
             // Handle application logic here and build your model
             return new RegisterModel() { PasswordLength = 12 };
         }
    }
