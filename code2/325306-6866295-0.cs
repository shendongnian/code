    private void OnItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || 
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblDescription = (Label)e.Item.FindControl("dgLabel1");
    
            if(lblDescription.Length > 50)
               lblDescription.Text = lblDescription.Text.SubString(0, 47) + "...";
               // Or add space after 50 characters.
        }
    }
