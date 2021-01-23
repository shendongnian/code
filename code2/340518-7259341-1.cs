    protected void repeater_OnItemDataBound(object sender, RepeaterItemEventArgs  e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        {
            foreach (Control c in e.Item.Controls)
            {
                if (c is Label)
                {
                    // Grab label
                    Label lbl = c as Label;
                    String your_value = lbl.Text;
                }
            }
        }    
    
