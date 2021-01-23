    private void OnItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || 
            e.Item.ItemType == ListItemType.AlternatingItem)
        {   
            if(e.Item.Cells[3].Text > 50)
               e.Item.Cells[3].Text= e.Item.Cells[3].Text.SubString(0, 47) + "...";
               // Or add space after 50 characters.
        }
    }
