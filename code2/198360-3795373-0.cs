    DataTable t1 = new DataTable("Employees");
    t1.Columns.Add("column1", typeof(string));
    t1.Columns.Add("column2", typeof(string));
    t1.Columns.Add("column3", typeof(string));
    
    DataRow newrow = t1.NewRow();
    ...
