    using (var connSQL = new SqlConnection(strConn)) 
    using (var commSQL = connSQL.CreateCommand()) 
    {
        connSQL.Open();
        commSQL.CommandText = strPreparedStatement;
        if (sqlParameters != null)
        {
            for (int i = sqlParameters.GetLowerBound(0); i <= sqlParameters.GetUpperBound(0); i++)
            {
                commSQL.Parameters.Add(sqlParameters[i]);
            }
        }
        using (var drSQL = commSQL.ExecuteReader())
        {
            dtReturn.Load(drSQL);
        }
    }
