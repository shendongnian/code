    public class myController : Controller
    {
        NameValueCollection myKeys = ConfigurationManager.AppSettings;
	
	    public void MyMethod()
        {
            var myUsername = myKeys["PFUserName"];
            var myPassword = myKeys["PFPassWord"];
        }
    }
