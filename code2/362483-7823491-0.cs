    public interface IRecord
    {
        DataTable Records {get;set;}
    } 
    
    public partial class resources_userControls_widget : System.Web.UI.UserControl, IRecord
    {
     ...
    }
