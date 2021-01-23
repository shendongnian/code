    int count;
    using (SqlCommand cmdCount = conn.CreateCommand())
    {
        cmdCount.CommandText = "SELECT COUNT(*) FROM [MyTable]";
        count = (int)cmdCount.ExecuteScalar();
    }
    // knowing the number of rows we can efficiently allocate the array
    double[] values = new double[count];
    using (SqlCommand cmdLoad = conn.CreateCommand())
    {
        cmdLoad.CommandText = "SELECT * FROM [MyTable]";
        using(SqlDataReader reader = cmdLoad.ExecuteReader())
        {
            int col = reader.GetOrdinal("MyColumnName");
            for(int i = 0; i < count && reader.Read(); i++)
            {
                values[i] = reader.GetDouble(col);
            }
        }
    }
    // do more processing on values[] here
