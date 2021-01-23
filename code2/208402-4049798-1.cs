    sql = @"
      update MyTable
        set Col1 = 1
        where ID in (select * from @ids)
      ";
    sqlCmd = new SqlCommand {Connection = _sqlConn, CommandText = sql};
    
    //Create a DataTable with one Column("id") and all ids as DataRows
    DataTable listOfLeadIDs = new DataTable();
    listOfIDs.Columns.Add("id", typeof(int));
    Ids.ToList<string>().ForEach(x => listOfIDs.Rows.Add(new object[] { int.Parse(x) }));
    
    //Bind this DataTable to the Command-object
    // Node: "IntTable" is an User-Defined-Table-Typ (new feature with SQL-2008)
    sqlCmd.Parameters.Add(
      new System.Data.SqlClient.SqlParameter("@ids", listOfIDs) { 
        TypeName = "IntTable" 
      });
    
    //Execute the Query
    sqlCmd.ExecuteNonQuery();
