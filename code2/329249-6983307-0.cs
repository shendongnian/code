    protected void gvTool_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["sortMode"] == null)
        {
            ViewState["sortMode"] = SORT_DESC;
        }
        if (ViewState["sortMode"] != null)
        {
            if (Convert.ToString(ViewState["sortMode"]).Trim().Equals(SORT_ASC))
            {
                ViewState["sortMode"] = SORT_DESC;
            }
            else
            {
                ViewState["sortMode"] = SORT_ASC;
            }
        }
        string sortexpr = e.SortExpression;
        ViewState["sortexpr"] = e.SortExpression;
        sort();
    }
    protected void sort()
    {
        if (ViewState["sortexpr"] != null)
        {
            DataView dvTool = default(DataView);
            DataTable dtTool = new DataTable();
            dtTool = (DataTable)ViewState["dtTool"];
            if ((dtTool != null))
            {
                if (dtTool.Rows.Count > 0)
                {
                    dvTool = dtTool.DefaultView;
                    dvTool.Sort = ViewState["sortexpr"].ToString().Trim() + " " + ViewState["sortMode"];
                    gvTool.DataSource = dvTool;
                    gvTool.DataBind();
                }
            }
        }
    }
