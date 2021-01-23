    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TestService : System.Web.Services.WebService
    {
        [WebMethod]
        [return: XmlArray("MyArray")]
        [return: XmlArrayItem("MyItem")]
        public List<string> HelloWorld()
        {
            return new List<string>() { "Hello World" };
        }
    }
