    void DetailsView1_ModeChanged(object sender, EventArgs e)
    {
        if (DetailsView1.CurrentMode != DetailsViewMode.Edit)
            return;
        foreach (DetailsViewRow row in DetailsView1.Rows)
        {
           var textbox = row.FindControl("txtName");
        }
    }
