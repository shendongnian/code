    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            listBind(); //procedure to populate your GridView
            DataSet dsSortTable = GridView1.DataSource as DataSet;
            DataTable dtSortTable = dsSortTable.Tables[0];
            if (dtSortTable != null)
            {
                DataView dvSortedView = new DataView(dtSortTable);
                dvSortedView.Sort = e.SortExpression + " " + getSortDirectionString();
                ViewState["sortExpression"] = e.SortExpression;
                GridView1.DataSource = dvSortedView;
                GridView1.DataBind();
            }
        }
