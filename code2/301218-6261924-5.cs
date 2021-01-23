    protected void OnItemDataBoundHandler(object sender, GridItemEventArgs e)
            {
                if (e.Item.IsInEditMode)
                {
                    GridEditableItem item = (GridEditableItem)e.Item;
    
                    if (!(e.Item is IGridInsertItem))
                    {
                        RadComboBox combo = (RadComboBox)item.FindControl("RadComboBox1");
                        
                        // create and add items here
                        RadComboBoxItem item = new RadComboBoxItem("text","value");
                        combo.Items.Add(item);
    
                    }
                }
            }
