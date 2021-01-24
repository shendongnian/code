    public class AccountDL
    {
        IConfiguration _configuration;
        OracleConnection _oracleConnection;
    	
    	public AccountDL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    	
        public string CreateUser(string conn, string username)
        {
            AppConfiguration appConfg = new AppConfiguration(_configuration);   
            _oracleConnection = appConfg.GetConnection(conn);
        }
    }
