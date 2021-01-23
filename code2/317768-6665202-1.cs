    protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
           if (e.CommandName == "Edit")
            {
                FormView1.ChangeMode(FormViewMode.Edit);
            }
           else if (e.CommandName == "Insert")
            {
                FormView1.ChangeMode(FormViewMode.Insert);
            }
    }
