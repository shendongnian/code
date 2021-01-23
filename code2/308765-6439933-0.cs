    [WebService(Namespace = "http://localhost:2900/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService()]
    public class WebServices1 : WebService
    {
        [WebMethod]
        public string PieTable(string table)
        {
            return table + " - resultant text";
        }
    }
