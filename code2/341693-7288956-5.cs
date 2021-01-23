    DataTable t = new DataTable();
    t.Columns.Add("id");
    t.Columns.Add("animal_name");
    foreach(var element in your animals_list)
    {
       DaraRow r = t.NewRow();
       r.ItemArray = new object[] { element.id, element.animal_name };
       t.Rows.Add(r);
    }
    
    // Assumes connection is an open SqlConnection.
    using (connection)
    {
        // Define the INSERT-SELECT statement.
        string sqlInsert = "INSERT INTO dbo.table1 (id, animal_name) SELECT nc.id, nc.animal_name FROM @animals AS nc;"
        
        // Configure the command and parameter.
        SqlCommand insertCommand = new SqlCommand(sqlInsert, connection);
        SqlParameter tvpParam = insertCommand.Parameters.AddWithValue("@animals", t);
        tvpParam.SqlDbType = SqlDbType.Structured;
        tvpParam.TypeName = "dbo.AnimalTable";
        
        // Execute the command.
        insertCommand.ExecuteNonQuery();
    }
