     protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            GridViewRow row = ((GridViewRow)((Button)e.CommandSource).NamingContainer);
            string name = row.Cells[0].Text;
            Label.Text = "You selected " + name + ".";
        }
    }
