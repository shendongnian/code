    RepositoryItemDateEdit riDateEdit = new RepositoryItemDateEdit();
    // Customize the item... 
    // Add the item to the control's internal repository. 
    treeList1.RepositoryItems.Add(riDateEdit);
    // Bind the item to the control's column. 
    treeList1.Columns["Start Date"].ColumnEdit = riDateEdit;
