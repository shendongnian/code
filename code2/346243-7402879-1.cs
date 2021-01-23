    public partial class ContentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
           //Add items to session 
           //....
    
            //Now refresh the updatepanel on the masterpage
            IMaster masterPage = Master as IMaster;
            masterPage.RefreshPanel();
        }
    }
