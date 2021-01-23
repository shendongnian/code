    protected void DetailsView1_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            DetailsView1.ChangeMode(DetailsViewMode.Edit);
        }
    }
