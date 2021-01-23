        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)grid.Rows[grid.SelectedIndex];
            string name = ((Label)row.Cells[1].Controls[1]).Text;
            Label.Text = "You selected " + name + ".";
        }
