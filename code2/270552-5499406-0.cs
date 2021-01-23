    protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int rownum = Convert.ToInt32(e.CommandArgument.ToString());
        foreach(GridViewRow row in sender.Rows)
        {
            if(row.Cells[0].Text == "a-value-")
            {
                 // Do something....
            }
        }
    }
