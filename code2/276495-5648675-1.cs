    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class Assets : WebService
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Validation));
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Response CityCreate(City city)
        {
            var response = new Response();
            // ... process and populate the return message, 
            // set the IsSuccess boolean property which will
            // be used by the client (see next...)
            return response;
        }
    }
