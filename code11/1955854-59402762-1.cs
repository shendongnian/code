    string sql = "DBCC CLONEDATABASE (SinglePoint, SinglePoint_1) " 
        + "ALTER DATABASE[SinglePoint_1] SET READ_WRITE";
    using (SqlConnection sqlConnection = new SqlConnection(ConnectionString)) {
        sqlConnection.Open();
        using (SqlCommand cmd = new SqlCommand(sql, sqlConnection)) {
            cmd.ExecuteNonQuery();
        }
    }
