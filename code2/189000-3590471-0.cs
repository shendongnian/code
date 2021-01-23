    foreach (DataRow row in productsDataTable.Rows)
    {
        var item = new ListViewItem(row[0].ToString());
    
        // Store the specific values you want to later retrieve
        item.Tag = new object[] { row["LocationList"], row["LocationIds] };
        // Or, store the whole row
        item.Tag = row;
    
        lvSearchResults.Items.Add(item);
    }
