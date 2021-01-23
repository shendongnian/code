      public partial class WebForm1 : System.Web.UI.Page
      {
        protected void Page_Load(object sender, EventArgs e)
        {
          
          if (Request.HttpMethod == "GET")
          {
            //Some parameter passed in by the client via QueryString (url)
            var id = Request.QueryString["id"];
            string data = GetTheData(id);
            Response.Write(data);
          }
        }
      }
