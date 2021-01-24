    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("value1", typeof(decimal));
    dataTable.Columns.Add("value2", typeof(decimal));
    
    dataTable.Rows.Add(null, 0.05);
    dataTable.Rows.Add(0.05M, 0.1M);
    dataTable.Rows.Add(null, 0.01);
    dataTable.Rows.Add(0.01, 0.02);
    List<SqlParameter> Parameters = new List<SqlParameter>();
    
    Parameters.Add(new SqlParameter("@AName", SqlDbType.Structured) { Value = dataTable, TypeName = "dbo.someUDT" });
    
    var dbContext = new test01Entities();
    dbContext.Database.ExecuteSqlCommand("Select * from @AName", Parameters.ToArray());
