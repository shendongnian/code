    // define the header
    public class AuthenticationHeader : SoapHeader
    {
        public String UserName { get; set; }
        public String Password { get; set; }
    }
    // your service
    public class PublicWebService : WebService
    {
        // defines an instance of the header as part of the service
        public AuthenticationHeader Authentication;
        private void Authenticate()
        {
            // validate the username / password against a database
            // set the HttpContext.Current.User if successful.
            // Maybe throw a SoapException() if authentication fails
        }
        // Notice the SoapHeader("Authentication") attribute...
        // This tells ASP.Net to look for the incoming header for this method...
        [WebMethod]
        [SoapHeader("Authentication")]
        public void PublicMethod1()
        {
            Authenticate();
            // your code goes here
        }
        // Expose another method with the same authentication mechanism
        [WebMethod]
        [SoapHeader("Authentication")]
        public void PublicMethod2()
        {
            Authenticate();
            // your code goes here
        }
    }
