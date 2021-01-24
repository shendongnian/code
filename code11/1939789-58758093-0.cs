     public class ServiceAuthenticator : UserNamePasswordValidator
    {
        private static readonly ILog _log = LogManager.GetLogger("ServiceAuthenticator");
        public override void Validate(String userName, string password)
        {
            _log.InfoFormat("--------Validate -{0}/{1}------------------------------", userName, password);
            if ((userName == null || userName.Trim().Length == 0) || (password == null || password.Trim().Length == 0))
            {
                _log.WarnFormat("  Missing User-name / Password  {0}/{1}", userName, password);
                throw new FaultException("Missing User-name / Password", new FaultCode("MISSINGUSERDETAILS"));
            }
            AuthUser.Username = userName;
            AuthUser.Password = password;
        }
    }
    public static class AuthUser
    {
        private static string name = "";
        public static string Username
        {
            get { return name; }
            set { name = value; }
        }
        private static string pswrd = "";
        public static string Password
        {
            get { return pswrd; }
            set { pswrd = value; }
        }
    }
