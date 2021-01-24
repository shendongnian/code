    DataGridView mainTable = new DataGridView();
    DataTable table = new DataTable();
    table.Columns.Add("A");
    table.Columns.Add("B");
    // ... skipping the part where I populate the data in the table, I know the entire data is truly there...
    mainTable.DataSource = table;
    this.Controls.Add(mainTable); // <- UI commands not ignored
    mainTable.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
