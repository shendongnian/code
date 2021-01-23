    public partial class MyMasterPage : System.Web.UI.MasterPage
    {
       public void ToggleSaveButton(bool visible)
       {
         SaveButton.Visible = visible
       }
    
       // other code
       ...
    }
