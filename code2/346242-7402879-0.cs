    public partial class MasterPage : System.Web.UI.MasterPage,  IMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Load items from session
        }
    
        public void RefreshPanel()
        {
            UpdatePanel1.Update();
        }
    }
