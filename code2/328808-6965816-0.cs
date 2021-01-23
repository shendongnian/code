    protected void GridView1_DataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text.Contains("sometext"))
                {
                    //code here..
                }
            }
        }
