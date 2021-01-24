    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    
        protected void GridViewUnmatched_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            GridViewMatched.DataBind();
        }
    
        protected void SqlDataSourceUnmatched_Updating(object sender, SqlDataSourceCommandEventArgs e)
        {            
            // assert the record update
            e.Command.Parameters["@Date"].Value = DateTime.Now;
        }
    }
