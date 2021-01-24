    private void M_Grid_ColumnHeaderClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
    {
        if (e.Column.DataMember == "Filed1")
        {
             //Removing any sort key that may be present in the table
            m_Grid.RootTable.SortKeys.Clear(); //or can be removed only specific 
           // sortkey
       
            // get the column to be sorted
            column = e.Column;
           
            if (e.Column.SortOrder == Janus.Windows.GridEX.SortOrder.Descending)
            {
                 sortKey = new GridEXSortKey(column, SortOrder.Ascending);
            }
            else
            {
              sortKey = new GridEXSortKey(column, SortOrder.Descending);
            }
           
           m_Grid.RootTable.SortKeys.Add(sortKey);
        }
    }
     
      
