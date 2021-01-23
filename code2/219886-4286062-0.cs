    public void SetOperationDropDown()
    {
    if(CmbOperations.Items.Count == 0)
    {
    //ByDefault the selected text in the cmbOperations will be -SELECT OPERATIONS-. 
    cmbOperations.SelectedItem = "-SELECT OPERATIONS-"; 
    //This is for adding four operations with value in operation dropdown 
    cmbOperations.Items.Insert(0, "PrimaryKeyTables"); 
    cmbOperations.Items.Insert(1, "NonPrimaryKeyTables"); 
    cmbOperations.Items.Insert(2, "ForeignKeyTables"); 
    cmbOperations.Items.Insert(3, "NonForeignKeyTables"); 
    cmbOperations.Items.Insert(4, "UPPERCASEDTables"); 
    cmbOperations.Items.Insert(5, "lowercasedtables"); 
            
            
    }
    else
    {
    int? cbSelectedValue = null;
    if(!string.IsNullOrEmpty(cmbOperations.SelectedValue))
    cbSelectedValue = convert.toInt32(cmbOperations.SelectedValue);
    }
    //load your combo again
    if(cbSelectedValue != null)
    cmbOperations.SelectedValue = cbSelectedValue.ToString();
    }
