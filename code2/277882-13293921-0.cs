    var datasource = myDataView.ToTable();
    
    treeView.BeginUpdate();
    
    // Iterate throght the DataRow Collection
    foreach (DataRow Row in datasource.Rows)
    {
    	TreeNode Node = treeView.Nodes.Add("Node for "+ Row.Field<string>("ColumnNameForNode"));
    
    	if (Node != null)
    	{
    		int iCol = 0;
    
    		foreach (var item in Row.ItemArray)
    		{
    			string itemString = item as string;
    			if (itemString != null && itemString.Length > 0)
    			{
    				Node.Nodes.Add(datasource.Columns[iCol].ColumnName + " - " + itemString);
    			}
    
    			iCol++;
    		}
    	}						
    }
    
    treeView.EndUpdate();
