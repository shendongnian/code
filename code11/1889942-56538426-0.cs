        using (DB db = new DB(_datasource, _initialCatalog))
        {
            db.OpenConnection();
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandText = QUERY_GETMATCHEDRECORD;
                command.Parameters.AddWithValue("@DBID", DBID);
                command.Parameters.AddWithValue("@recID", recID);
                command.Parameters.AddWithValue("@recDocID",recDocID);
                dt = db.ExecuteDataTable(command);
            }
            db.CloseConnection();
        }
