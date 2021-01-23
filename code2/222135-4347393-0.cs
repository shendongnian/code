    public partial class About : System.Web.UI.Page
    {
        public class Class2
        {
            public int i = 1;
            public string str = "Chandan";
            public string Data()
            {
                return i.ToString() + " " + str.ToString();
            }
        }
    
        
        protected void Page_Load(object sender, EventArgs e)
        {
        
            Class2 Object1 = new Class2();
            List<Class2> Object2 = new List<Class2>();
            Object2.Add(Object1);
            Response.Write("List count = " + Object2.Count.ToString());    
        }
    
    }
