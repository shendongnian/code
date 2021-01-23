    var dataTable = new DataTable();
    dataTable.Columns.Add("Id", typeof(int));
    dataTable.Columns.Add("Name", typeof(string));
    dataTable.Rows.Add(1, "Test1");
    dataTable.Rows.Add(2, "Test2");
    comboBox1.ItemsSource = dataTable.DefaultView;
    comboBox1.DisplayMemberPath = "Name";
