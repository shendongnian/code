    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CustomerWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public string Register(long id, string data1)
        {
            return "ID.CUSTOMER";
        }
    }
