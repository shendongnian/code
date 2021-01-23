    // Create the parent FlowDocument...
    flowDoc = new FlowDocument();
    
    // Create the Table...
    table1 = new Table();
    // ...and add it to the FlowDocument Blocks collection.
    flowDoc.Blocks.Add(table1);
    
    
    // Set some global formatting properties for the table.
    table1.CellSpacing = 10;
    table1.Background = Brushes.White;
