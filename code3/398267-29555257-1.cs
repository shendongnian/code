    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.IsInEditMode && e.Item is GridEditFormItem)
            {
               
                    // edit
                    GridEditFormItem item = e.Item as GridEditFormItem;
                    (item["column"].Controls[0] as TextBox).Enabled = false;
                
    
            }
        }
