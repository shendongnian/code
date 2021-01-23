    // Grid has two columns
    tlp.ColumnCount = 2;
     
    // Grid has two rows
    tlp.RowCount = 2;
     
    // If grid is full add extra cells by adding column
    tlp.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
     
    // Padding (pixels)within each cell (left, top, right, bottom)
    tlp.Padding = new Padding(1, 1, 4, 5);
     
    // Add TableLayoutPanel to the Forms controls
    this.Controls.Add(tlp);
