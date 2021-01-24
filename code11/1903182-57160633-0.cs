    protected void OnItemDataBoundHandler(object sender, GridItemEventArgs e)
    {
        if (e.Item.IsInEditMode)
        {
            GridEditableItem item = (GridEditableItem)e.Item;
            if (!(e.Item is IGridInsertItem))
            {
                RadComboBox combo = (RadComboBox)item.FindControl("RadComboBox1");
                RadComboBoxItem selectedItem = new RadComboBoxItem();
                selectedItem.Text = ((DataRowView)e.Item.DataItem)["CompanyName"].ToString();
                selectedItem.Value = ((DataRowView)e.Item.DataItem)["SupplierID"].ToString();
                selectedItem.Attributes.Add("ContactName", ((DataRowView)e.Item.DataItem)["ContactName"].ToString());
                combo.Items.Add(selectedItem);
                selectedItem.DataBind();
                Session["SupplierID"] = selectedItem.Value;
            }
        }
    }
