     protected void DocumentGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmd")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                GridViewRow row = DocumentGrid.Rows[index];
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Response.Write(row.Cells[0].Text);
                }
            }
        }
