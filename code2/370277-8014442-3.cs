    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = GridView1.Rows[(int)e.CommandArgument];
        if (row != null)
        {
            TextBox txt = row.FindControl("TextBox1") as TextBox;
            if (txt != null)
            {
                //get the value from the textbox
                string value = txt.Text;
            }
        }
    }
