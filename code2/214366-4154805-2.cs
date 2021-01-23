     public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                Person objP = new Person();
                objP.FirstName = "John";
                objP.LastName = "Doe";
    
                objP.Attributes = new Dictionary<string, string>();
    
                objP.Attributes.Add("PhoneNumber", "12345");
                objP.Attributes.Add("StreetName", "StackOverFlow Street");
                objP.Attributes.Add("StreetNumber", "51");
    
                DictionarySerializer ds = new DictionarySerializer();
                string val = ds.WriteXml(objP);
            }
        }
