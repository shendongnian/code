    public string SortingExpression
    {
        get
        {
            if (this.ViewState["SortExpression"] == null)
                return "";
            else
                return (string)this.ViewState["SortExpression"];
        }
        set
        {
            this.ViewState["SortExpression"] = value;
        }
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable m_DataTable = GridView1.DataSource as DataTable;
        if (m_DataTable != null)
        {
            DataView m_DataView = new DataView(m_DataTable);
            SortingExpression = e.SortExpression + " " + (SortingExpression.Contains("ASC") ? "DESC" : "ASC");
            m_DataView.Sort =SortingExpression;
            GridView1.DataSource = m_DataView;
            GridView1.DataBind();
        }
    }
