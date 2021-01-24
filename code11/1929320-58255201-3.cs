      //Removing any sort key that may be present in the table
      m_Grid.RootTable.SortKeys.Clear();
    
        // get the column to be sorted
        column = m_Grid.RootTable.Columns("Filed1");
    
        // create the sort key
        sortKey = new GridEXSortKey(column, SortOrder.Ascending);
    
        // add the sort key to the SortKeys collection of the table
         m_Grid.RootTable.SortKeys.Add(sortKey);
    
        // to sort by more than one column, create as many sort keys
        // as are needed and add them to the SortKeys collection.
    
    
      
