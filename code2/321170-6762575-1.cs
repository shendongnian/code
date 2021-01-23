    var dt1 = new DataTable("Test");
    dt1.Columns.Add("id", typeof(int));
    dt1.Columns.Add("name", typeof(string));
    
    var dt2 = new DataTable("Test");
    dt2.Columns.Add("id", typeof(int));
    dt2.Columns.Add("name", typeof(string));
    
    dt1.Rows.Add(1, "Apple"); dt1.Rows.Add(2, "Oranges");
    dt1.Rows.Add(3, "Grapes");
    dt1.AcceptChanges();
    
    dt1.Rows[0].Delete();
    dt2.Merge(dt1);
    dt2.AcceptChanges(); 
    dt1.RejectChanges();
