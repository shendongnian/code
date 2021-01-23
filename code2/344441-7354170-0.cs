    //Create a new column to add to the DataGrid
    DataGridTextColumn textcol = new DataGridTextColumn();
    //Create a Binding object to define the path to the DataGrid.ItemsSource property
    //The column inherits its DataContext from the DataGrid, so you don't set the source
    Binding b = new Binding("LastName");
    //Set the properties on the new column
    textcol.Binding = b;
    textcol.Header = "Last Name";
    //Add the column to the DataGrid
    DG2.Columns.Add(textcol);
