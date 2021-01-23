    using System.Web.Script.Serialization;
    public class Json
    {
        public string getJson()
        {
           // some code //
           var products = // IEnumerable object //
           string json = new JavaScriptSerializer().Serialize(products);
           // some code //
           return json;
        }
    }
