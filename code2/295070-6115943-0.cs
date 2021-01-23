        public class MyPage : System.Web.UI.Page
        {
            public MyPage()
            {
                Load += MyPage_Load;
            }
            void MyPage_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    if (Page.Request.UrlReferrer == null)
                    {
                        Response.Redirect("test.aspx");
                    }
                }
            }
        }
