    [Serializable]
    class Stuff
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
    }
    [Serializable]
    class Test1
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string FavColor { get; set; }
        public string FavFood { get; set; }
        public Stuff boo { get; set; }
    }
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class BudgetGrid : System.Web.Services.WebService
    {
        [WebMethod(true)]
        public string SaveLineItemDetails(string details, int categoryId, int lineItemId)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Test1 boo1 = serializer.Deserialize<Test1>(details);
            return "";
        }
    }
