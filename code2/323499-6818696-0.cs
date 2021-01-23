    protected void detailsNew_DataBound(object sender, EventArgs e)
    {
        if (detailsNew.CurrentMode == DetailsViewMode.Insert)
        {
            string v = ((TextBox)detailsNew.FindControl("txtTransactionName")).Text;
        }
    }
