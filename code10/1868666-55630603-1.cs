    DataGridTextColumn c1 = new DataGridTextColumn();
    c1.Header = "Name";
    c1.Binding = new Binding("Name");
    data.Columns.Add(c1);
            
    DataGridTextColumn c2 = new DataGridTextColumn();
    c2.Header = "Quantity";
    c2.Binding = new Binding("Quantity");
    data.Columns.Add(c2);
            
    data.Items.Add(new RowType() { Name = "a", Quantity = "one" });
    data.Items.Add(new RowType() { Name = "b", Quantity = "two" });
