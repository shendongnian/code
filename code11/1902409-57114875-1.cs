    DataGrid dg = (DataGrid)sender;
    MainViewModel mvm = (MainViewModel)this.DataContext;
    Type classType = typeof(Person);
    PropertyInfo[] properties = classType.GetProperties();
    foreach (PropertyInfo prop in properties) {
    	dg.Columns.Add(new DataGridTextColumn() {
    		Binding = new Binding(prop.Name),
    		Header = prop.Name
    	});
    }
