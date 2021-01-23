    public void PopulateColumns() {
        GridViewDataTextColumn colID = new GridViewDataTextColumn();
        colID.FieldName = "ID";
        ASPxGridView1.Columns.Add(colID);
    
        GridViewDataHyperLinkColumn colItemName = new GridViewDataHyperLinkColumn();
        colItemName.FieldName = "ItemName";
        colItemName.PropertiesHyperLinkEdit.NavigateUrlFormatString ="~/details.aspx?Device={0}";
        colItemName.PropertiesHyperLinkEdit.TextFormatString = "Device {0}";
        colItemName.PropertiesHyperLinkEdit.TextField = "ItemName";
        ASPxGridView1.Columns.Add(colItemName);
    }
