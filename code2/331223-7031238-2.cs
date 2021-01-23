    // MyOtherFile.cs:
    namespace MyWebSite.UserControls
    {
        public partial class MyUserControl : System.Web.UI.UserControl
        {
            protected override void OnInit(System.EventArgs e)
            {
                base.OnInit(e);
    
                _gridView.OnRowCommand += _gridBiew_RowCommand;
                _gridView.OnDataBound += _gridView_DataBound;
            }
    
            // events here...
        }
    }
