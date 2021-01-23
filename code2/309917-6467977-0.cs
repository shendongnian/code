    protected void grd_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (e.SortExpression == hdfSortExp.Value)
            {
                if (hdfUpDown.Value == "1")
                    hdfUpDown.Value = "0";
                else
                    hdfUpDown.Value = "1";
            }
            else //New Column clicked so the default sort direction will be incorporated
                hdfUpDown.Value = "0";
    
            hdfSortExp.Value = e.SortExpression; //Update the sort column
            BindGrid(hdfSortExp.Value, this.CBool(hdfUpDown.Value));
        }
