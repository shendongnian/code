    public static string CreateHash(string password)
    {
        return CreateHash(password, CreateSalt());
    }
    private static string CreateHash(string password, string salt)     
    {         
        string saltAndPassword = String.Concat(password, salt);         
        string hashedPassword = 
            FormsAuthentication.HashPasswordForStoringInConfigFile(
                             saltAndPassword,"SHA1");         
        hashedPassword = string.Concat(hashedPassword,salt);         
        return hashedPassword;     
    } 
        public static bool VerifyPassword(string username, 
                        string password,AccountDataContext context)
        {
            var user = context.UserAccounts.FirstOrDefault(p => p.UserName == username);
            if (user != null)
            {
                string salt = user.Password.Substring(user.Password.Length - DefaultSaltSize);
                string hashedPassword = CreateHash(password, salt);
                return hashedPassword.Equals(user.Password);
            }
            return false;
            
        }
