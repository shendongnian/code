    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
          Session["SearchTable"] = gv_GridView.DataSource;
          LoadSearchGrid("Select * from WF_Search);
    }
    private void LoadSearchGrid(string query)
    {
        DataTable dsp = new DataTable();
        conn = new SqlConnection(ConnectionString);
        SqlDataAdapter sda = new SqlDataAdapter(query, conn);
        conn.Open();
        sda.Fill(dsp);
        Session["SearchTable"] = dsp;
        gv_GridView.DataSource = Session["SearchTable"];
        gv_GridView.DataBind();
        conn.Close();
        sda.Dispose();
    }
    protected void gv_GridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortDirection"] = e.SortDirection;
        DataTable dtr = Session["SearchTable"] as DataTable;
        if (dtr != null)
        {
            dtr.DefaultView.Sort = e.SortExpression + " " + getSortDirection(e.SortExpression);
            gv_GridView.DataSource = Session["SearchTable"];
            gv_GridView.DataBind();
            Session["SearchTable"] = gv_GridView.DataSource;
        }
    }
    private string getSortDirection(string column)
    {
        string sortDirection = "ASC";
        string sortExpression = ViewState["SortDirection"] as string;
        if (sortExpression != null)
        {
            if (sortExpression == column)
            {
                string lastDirection = ViewState["SortDirection"] as string;
                if (lastDirection != null && lastDirection == "ASC")
                {
                    sortDirection = "DESC";
                }
            }
        }
        ViewState["SortDirection"] = sortDirection;
        ViewState["SortExpression"] = column;
        return sortDirection;
    }
    protected void gv_GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_GridView.DataSource = Session["SearchTable"];
        gv_GridView.DataBind();
        gv_GridView.PageIndex = e.NewPageIndex;
    }
