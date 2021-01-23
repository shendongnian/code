     protected void gvExcel_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[22].Attributes.Add("class", "cost");
            }
        } 
