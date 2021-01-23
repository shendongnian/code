    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            IPageInterface pageInterface = Page as IPageInterface;
            if (pageInterface != null)
            {
                pageInterface.DoSomeAction();
            }
        }
    }
