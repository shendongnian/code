    void DetailsView_DataBound(object sender, EventArgs e)
    {
        foreach (BoundField field in this.DetailsView.Fields)
        {
            field.ItemStyle.BackColor = GetColorValue((decimal)
                this.DetailsView.DataItem.GetType()
                .GetProperty(field.DataField)
                .GetValue(this.DetailsView.DataItem, null));
        }
    }
