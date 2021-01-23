    public class LoginResult
    {
        public LoginResult(int clientType, int clientId)
        {
             ClientType = clientType;
             ClientID = clientId;
        }
        public int ClientType { get; set; };
        public int ClientID{ get; set; };
    }
    [WebMethod]        
    public LoginResult Login(string url, string id)
    {
        return new LoginResult( 11, 12 );      
    }
