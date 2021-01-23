    SqlMetaData[] columns = new SqlMetaData[3];
    columns[0] = new SqlMetaData("Value1", SqlDbType.Int);
    columns[1] = new SqlMetaData("Value2", SqlDbType.Int);
    columns[2] = new SqlMetaData("Value3", SqlDbType.Int);
    SqlDataRecord record = new SqlDataRecord(columns);
    SqlContext.Pipe.SendResultsStart(record);
    SqlDataReader reader = comm.ExecuteReader();
    bool flag = true;
 
    while (reader.Read() && flag)
    {
        int value1 = Convert.ToInt32(reader[0]);
        int value2 = Convert.ToInt32(reader[1]);
         
        // some algorithm 
        int newValue = ...;
        reader.SetInt32(3, newValue);        
        SqlContext.Pipe.SendResultsRow(record);
        // keep going?
        flag = newValue < 100;
     }
