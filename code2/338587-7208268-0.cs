    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        GridViewRow row = GridView1.Rows[(int)e.CommandArgument];
        if (row != null)
        {
            //do some logic on the row
        }
        //do some other logic outside of the row
    }
