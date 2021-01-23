    void CallDatabase( /* your parameters */)
    {
        try
        {
            string insertData = string.Format("INSERT INTO " + constants.PIZZABROADCASTTABLE + " VALUES(@starttime,@endtime,@lastupdatetime,@applicationname)");
            sqlCommand = new SqlCommand(insertData, databaseConnectivity.connection);
            sqlCommand.Parameters.AddWithValue("@starttime", broadcastStartDateTime);
            sqlCommand.Parameters.AddWithValue("@endtime", broadcastEndDateTime);
            sqlCommand.Parameters.AddWithValue("@lastuptime", currentDateTime);
            sqlCommand.Parameters.AddWithValue("@applicationname", txtApplicationName.Text);
            sqlCommand.ExecuteNonQuery();
        
        }
        catch (SqlException ex)
        {
            throw new DataBaseException("Database error", ex);
        }
    }
    /* somewhere in your code */
    try
    {
       CallDatabase(...);
    }
    catch (DataBaseException ex)
    {
        MessageBox.Show(ex.Message);
    }
