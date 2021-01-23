    using System.Web.Script.Services;
    using System.Web.Services;
    
    namespace jQueryAutoCompleteBackEnd
    {
        /// <summary>
        /// Summary description for Service1
        /// </summary>
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        [ScriptService]
        public class Service1 : WebService
        {
    
            [WebMethod]
            [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
            public string[] GetCitiesWithState(string isoalpha2, string prefixText)
            {
                return new string[] { "New Orleans, Lousiana", "New York, New York" };
            }
    
        }
    }
