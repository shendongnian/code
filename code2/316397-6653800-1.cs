    public class TestTemplate : Button
    {
        public TestTemplate()
        {
            this.Text = "Click Me";
            this.ID = "btnClickMe";
            this.Click += new System.EventHandler(this.EventHandler);
            //
            // TODO: Add constructor logic here
            //
        }
    
        public void EventHandler(object sender, EventArgs e)
        {
            //System.Web.HttpContext.Current.Server.Transfer("Default.aspx");
            System.Web.HttpContext.Current.Response.Write("This is a test!");
        }
    }
