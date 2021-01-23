     protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            SetSortDirection(SortDirection);
            if (dt != null)
            {
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SortDireaction = _sortDirection;
            }
        }
