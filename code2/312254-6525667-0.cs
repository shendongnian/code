    DataTable dt1 = new DataTable();
    dt1.Columns.Add("ID", typeof(int));
    dt1.Columns.Add("Customer", typeof(string));
    dt1.PrimaryKey = new[] { dt1.Columns["ID"] };
    dt1.Rows.Add(new object[] { 1, "Ahmad" });
    
    DataTable dt2 = new DataTable();
    dt2.Columns.Add("ID", typeof(int));
    dt2.Columns.Add("Customer", typeof(string));
    dt2.PrimaryKey = new[] { dt2.Columns["ID"] };
    dt2.Rows.Add(new object[] { 1, "Mageed" });
    
    // try without primary keys and it'll add a new record
    dt1.Merge(dt2);
