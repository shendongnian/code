    public class User
    {
        private const string CN_LoginId = "Login";
        private const string CN_Password = "Password";
    
        public string Password { get; set; }
    
        public static User Create(string Login)
        {
            User usr = new User();
            using (DataTable dt = DAC.ExecuteDataTable("usp_PasswordSelect", 
                DAC.Parameter(CN_LoginId, Login)))
                {
                    usr.Password = Convert.ToString(dt.Rows[0][CN_Password]);
                }
            return usr;
        }
    }
