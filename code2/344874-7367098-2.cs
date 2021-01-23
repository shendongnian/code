    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class TableManager : WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Process(string tableContents)
        {
            var table = Server.HtmlDecode(tableContents);
            // Do Something (Email, Parse, etc...).
        }
    }
