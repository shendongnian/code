    protected void grid_RowCommand(object sender, GridViewCommandEventArgs e) {
        if (e.CommandName == "Select") {
            int RowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid.Rows[RowIndex];
            string a = row.Cells[4].Text;
            Label.Text = "You selected " + a + ".";
        }
    }
