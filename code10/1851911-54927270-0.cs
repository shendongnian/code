    // creating table-valued parameter
    var yourDataTable = new DataTable();
    yourDataTable.Columns.Add("ID", typeof(int));
    yourDataTable.Columns.Add("CarNumber");
    
    //inserting data into table valued parameter
    yourDataTable.Rows.Add(1, "Hello, World!");
    //Parameter declaration
    SqlParameter[] Parameter = new SqlParameter[1];    
    Parameter[0].ParameterName = "@FooParameters";    
    Parameter[0].SqlDbType = SqlDbType.Structured;    
    Parameter[0].Value = yourDataTable;    
    // Executing Stored Procedure
    SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.StoredProcedure, " 
        [YourStoredProcedure]", Parameter);  
