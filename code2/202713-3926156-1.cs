    // Set up the table adapter and new row
    MyDataSetTableAdapters.EmployeeTableAdapter adapter;
    adapter = new MyDataSetTableAdapters.EmployeeTableAdapter();
    MyDataSet.EmployeeDataTable table = adapter.GetData();
    MyDataSet.EmployeeRow newRow;
    newRow = table.NewEmployeeRow();
    // Insert the values of the fields into the new row here
    // Save the row
    table.AddEmployeeRow(newRow);
    adapter.Update(table);
