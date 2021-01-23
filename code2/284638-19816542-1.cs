    public void GridView_RowCommand(Object sender, GridViewCommandEventArgs e)
            {
                string t;
                if (e.CommandName == "Delete")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow selectedRow = grid1.Rows[index];
                    t = selectedRow.Cells[2].Text;
                }
            }
