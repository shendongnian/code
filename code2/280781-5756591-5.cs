    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class handler : IHttpHandler , System.Web.SessionState.IReadOnlySessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            DateTime dateStamp = DateTime.Parse((string)Request.Form["dateStamp"]);
            string stringParam = (string)Request.Form["stringParam"];
            // Your logic here
            string json = "{ \"responseDateTime\": \"hello hello there!\" }";
            context.Response.Write(json);    
        }
