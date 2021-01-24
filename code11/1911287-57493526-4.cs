    DataTable dataTable = new DataTable();
    
    dataTable.Columns.Add(new DataColumn(nameof(Product.Name)));
    dataTable.Columns.Add(new DataColumn(nameof(Product.Price)));
    dataTable.Columns.Add(new DataColumn(nameof(Product.Condition)));
    
    foreach (var product in products)
    {
    	var row = dataTable.NewRow();
    	row[nameof(Product.Name)] = product.Name;
    	row[nameof(Product.Price)] = product.Price;
    	row[nameof(Product.Condition)] = product.Condition;
    	dataTable.Rows.Add(row);
    }
