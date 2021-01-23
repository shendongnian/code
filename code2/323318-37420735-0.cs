    void gvReport_Sorting(object sender, GridViewSortEventArgs e)
    {        
        System.Data.DataTable dataTable = ViewState["dataTable"] as System.Data.DataTable;
        string sortDirection = (ViewState["sortDirection"].ToString() == "ASC" ? "DESC" : "ASC");
        ViewState["sortDirection"] = sortDirection;
        if (dataTable != null)
        {
            System.Data.DataView dataView = new System.Data.DataView(dataTable);
            dataView.Sort = String.Format("{0} {1}", e.SortExpression, sortDirection);
            gvReport.DataSource = dataView;
            gvReport.DataBind();
        }
    }
