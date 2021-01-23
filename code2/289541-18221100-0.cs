protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
{
    string commandName = e.CommandName;
    switch (commandName)
        {
            case "Page1":
                HandlePageCommand(e);
                //binding should happen here
                break;
        }
        //this line is in the wrong location, causing the bug    
        BindGrid1();
}
