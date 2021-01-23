    test_DataEntities db = new test_DataEntities();
    DataGrid test = new DataGrid();
    List<testTblEntity> list = db.testTbls.ToList(); // executes the query
    test.ItemsSource = list;
    cmbWorkOrder.ItemsSource = list.Select(t => t.PropertyToDisplayInComboBox);
