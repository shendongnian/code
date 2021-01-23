    protected void gvOutlookMeldingen_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dt = (DataTable)Session["mySessionStoredTable"];
        dt.DefaultView.Sort = e.SortExpression // column name
            + " " + SortDir(e.SortExpression); // sort direction
        gv.DataSource = dt;
        gv.DataBind();
    }
    private string SortDir(string sColumn)
    {
        string sDir = "asc"; // ascending by default
        string sPreviousColumnSorted = ViewState["SortColumn"] != null 
            ? ViewState["SortColumn"].ToString() 
            : "";
        if (sPreviousColumnSorted == sColumn) // same column clicked? revert sort direction
            sDir = ViewState["SortDir"].ToString() == "asc" 
                ? "desc"
                : "asc";
        else
            ViewState["SortColumn"] = sColumn; // store current column clicked
        ViewState["SortDir"] = sDir; // store current direction
        return sDir;
    }
