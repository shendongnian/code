        [WebService(Namespace = "http://www.mynamespace.com")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]        
        public class ConstantService : System.Web.Services.WebService
        {
            public const DateTime NullDate = DateTime.Parse("01/01/2000 00:00");
    
            [WebMethod]
            public DateTime getNullDate()
            {                
                return NullDate;
            }
        }
