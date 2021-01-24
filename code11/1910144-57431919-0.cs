    bool canCompress = false;
    using (SqlDataReader reader = sqlCmd.ExecuteReader())
    {
        while (reader.Read())
        {
            canCompress = reader.GetInt32(0) == 1;                                      
        }
    }
    if (canCompress)
    {
        ...
    }
    else
    {
        ...
    }
