    public partial class YourMasterPage : System.Web.UI.MasterPage
    {
       public bool IsLogoutClicked()
       {
         return null != Request.Form[LogoutButton.UniqueID];
       }
    
       ...
    }
