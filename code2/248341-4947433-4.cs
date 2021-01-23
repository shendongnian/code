    public void MyGridView_OnRowCommand(Object sender, GridViewCommandEventArgs e)
    {
        var label = ((Button)e.CommandSource).Parent.FindControl("MyStatusLabel") as Label;
        label.Text = e.CommandName;
    }
