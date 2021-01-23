    public partial class Requests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindgrdBuilds();
            }
        }
        
        private void BindgrdBuilds()
        {
            // Link GridView to datasource
            GridView1.DataSource = BuildData.getBuilddata();
            // Bind SQLDataSource to GridView after retrieving the records.
            GridView1.DataBind();
        }
        public void GridView1_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            // increment PageIndex
            GridView1.PageIndex = e.NewPageIndex;
            // bind table again
            BindgrdBuilds();
        } 
    }
