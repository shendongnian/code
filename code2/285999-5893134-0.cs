    public class Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            string data = DoXMLRequest();
            ucControl1.Data = data;
            ucControl2.Data = data;
            ucControl3.Data = data;
        }
    }
