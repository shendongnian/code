    // Let's say I have this list of cars I want to add to my datagridview
    List<Car> cars = new List<Car>();
    cars.Add(new Car() { Index = 0, Make = "Ford" });
    cars.Add(new Car() { Index = 1, Make = "Chevvy" });
    cars.Add(new Car() { Index = 2, Make = "Toyota" });
    
    // I create the column, setting all the various properties
    DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
    col.DataSource = cars;
    col.Name = "Cars";
    col.DisplayMember = "Make";
    col.HeaderText = "Car";
    col.ValueMember = "Index";
    col.DataPropertyName = "Car";
    
    // As well as standard properties for a combobox column I set these two:
    col.DefaultCellStyle.NullValue = cars[0].Make;
    col.DefaultCellStyle.DataSourceNullValue = cars[0].Index;
    
    dataGridView1.Columns.Add(col);
    
    dataGridView1.DataSource = dt;
