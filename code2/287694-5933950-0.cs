    protected void OtherGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            var SortExpression = e.SortExpression + " " + getSortDirectionString(e.SortDirection);
            gvMeldingen.DataSource = ... // Requery the Data using the new sort expression above
            gvMeldingen.DataBind();
        }
