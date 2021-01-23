    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WebService : System.Web.Services.WebService
    {
        [WebMethod]
        public HelloWorldOutput HelloWorld(HelloWorldInput input)
        {
            try
            {
                // My Code
                return new HelloWorldOutput();
            }
            catch (Exception ex)
            {
                throw new SoapException("Hello World Exception",   
                     SoapException.ServerFaultCode, "HelloWorld", ex);
            }
        }
    }
