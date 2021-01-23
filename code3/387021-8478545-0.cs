    void yourDv_ModeChanged(object sender, EventArgs e)
    {
        if ((sender as DetailsView).CurrentMode != DetailsViewMode.Edit)
            return;
        foreach (DetailsViewRow row in DetailsView1.Rows)
        {
           var textbox = row.FindControl("txtName");
        }
    }
