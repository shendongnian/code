    // create table
    var dt = new System.Data.DataTable("tableName");
    // create fields
    dt.Columns.Add("field1", typeof(int));
    dt.Columns.Add("field2", typeof(string));
    dt.Columns.Add("field3", typeof(DateTime));
    // insert row values
    dt.Rows.Add(new Object[]{
                    123456,
                    "test",
                    DateTime.Now
               });
