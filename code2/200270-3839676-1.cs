    //Add a second connection based on the first one
    SqlConnection objConn2= new SqlConnection(objConn.connectionString))
    
    SqlCommand objInsertCommand= new SqlCommand();
    objInsertCommand.CommandType = CommandType.Text;
    objInsertCommand.Connection = objConn2;
    
    while (objDataReader.Read())
    {
        objInsertCommand.CommandText = "INSERT INTO tablename (field1, field2) VALUES (3, '" + objDataReader[0] + "')";
        objInsertCommand.ExecuteNonQuery();
    }
