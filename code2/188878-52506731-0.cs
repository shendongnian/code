    // Call Method
    SelectDropdownItemByText(ddlDropdown.Items.FindByText("test"));
    // Define method
    public void SelectDropdownItemByText(ListItem item)
    {
        if (item != null)
        {
            item.Selected = true;
        }
    }
