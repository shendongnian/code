    namespace WebApplication1
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            private static int times = 0;
    
            protected void Page_Load(object sender, EventArgs e)
            {
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                times++;
                Label1.Text = times.ToString();
            }
        }
    }
