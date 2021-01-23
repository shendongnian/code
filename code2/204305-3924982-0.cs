    DataTable table = new DataTable();
    table.Columns.Add("Fruit");
    table.Columns.Add("ID", typeof(int));
    table.Rows.Add(new object[] { "Lemon", 1 });
    table.Rows.Add(new object[] { "Orange", 1 });
    table.Rows.Add(new object[] { "Apple", 2 });
    table.Rows.Add(new object[] { "Pear", 2 });
    
    BindingSource bs = new BindingSource();
    bs.DataSource = from row in table.AsEnumerable()
    						   where row.Field<int>("ID") == 1
    						   select new {Fruit = row.Field<string>("Fruit"), ID = row.Field<int>("ID")};
    
    dataGridView1.DataSource = bs;
