     protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "createNewRecord")
        {
                 //Another Gridview will be created here, and it will contains EditTemplate.
                 //you can use that gridview to receive data by Edit.
        }
    }
