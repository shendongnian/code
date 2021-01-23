    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class CitiService : WebService
    {
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<tbl_City> GetAllCitiesByCountry(int countryID)
        {
         List<tbl_City> cities = GetCities(countryID);
         JavaScriptSerializer js = new JavaScriptSerializer();
            var jsonObj = js.Serialize(cities);
            Context.Response.Clear();
            Context.Response.Write(jsonObj);
            Context.Response.End();
         }
     }
