    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataSet m_DataTable = (DataSet)ViewState["itemsetPending"];
   
        if (m_DataTable != null)
        {
            DataView m_dataview = new DataView(m_DataTable.Tables[0]);
            if (Convert.ToInt32(ViewState["m_sort"]) == 0)
            {
                m_dataview.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(SortDirection.Descending);
                ViewState["m_sort"] = 1;
            }
            else
            {
                m_dataview.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                ViewState["m_sort"] = 0;
            }
            GridView1.DataSource = m_dataview;
            GridView1.DataBind();
        }
    }
