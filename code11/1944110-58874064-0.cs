    protected void GridView1_DataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[5].Age < 18)
                {
                     e.Row.Enabled = false;
                }
            }
        }
