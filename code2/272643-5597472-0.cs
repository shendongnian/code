    // ... SQL connection and command set up, only querying 1 row from the table
    StringBuilder sb = new StringBuilder();
    StringWriter sw = new StringWriter(sb);
    JsonWriter jsonWriter = new JsonTextWriter(sw);
    
    try {
    
        theSqlConnection.Open(); // open the connection
    
        // read the row from the table
        SqlDataReader reader = sqlCommand.ExecuteReader();
        reader.Read();
    
        int fieldcount = reader.FieldCount; // count how many columns are in the row
        object[] values = new object[fieldcount]; // storage for column values
        reader.GetValues(values); // extract the values in each column
    
        jsonWriter.WriteStartObject();
        for (int index = 0; index < fieldcount; index++) { // iterate through all columns
    
            jsonWriter.WritePropertyName(reader.GetName(index)); // column name
            jsonWriter.WriteValue(values[index]); // value in column
    
        }
        jsonWriter.WriteEndObject();
                
        reader.Close();
    
    } catch (SqlException sqlException) { // exception
        context.Response.ContentType = "text/plain";
        context.Response.Write("Connection Exception: ");
        context.Response.Write(sqlException.ToString() + "\n");
    } finally {
        theSqlConnection.Close(); // close the connection
    }
    // END of method
    // the above method returns sb and another uses it to return as HTTP Response...
    StringBuilder theTicket = getInfo(context, ticketID);
    context.Response.ContentType = "application/json";
    context.Response.Write(theTicket);
