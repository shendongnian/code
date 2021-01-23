    public partial class GridViewSort : System.Web.UI.Page
    {
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
    
        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;
    
                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;
    
            GridView1.DataSource = GetStaff();
            GridView1.DataBind();
        }
    
    
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
    
            string sortExpression = e.SortExpression;
    
            if (GridViewSortDirection == SortDirection.Ascending)
            {
                GridViewSortDirection = SortDirection.Descending;
                SortGridView(sortExpression, DESCENDING);
            }
            else
            {
                GridViewSortDirection = SortDirection.Ascending;
                SortGridView(sortExpression, ASCENDING);
            }   
        }
    
        private void SortGridView(string sortExpression, string direction)
        {
            DataTable dt = GetStaff();
    
            DataView dv = new DataView(dt);
            dv.Sort = sortExpression + direction;
    
            GridView1.DataSource = dv;
            GridView1.DataBind();
        }
    
        /// <summary>
        /// Dummy data
        /// </summary>
        /// <returns></returns>
        private DataTable GetStaff()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Age", typeof(int));
    
            for (int i = 1; i <= 20; i++)
            {
                dt.Rows.Add(i, "Staff - " + i, 20 );
            }
    
            return dt;
        }
    }
