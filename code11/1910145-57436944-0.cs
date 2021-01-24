    using (SqlConnection dbConnection = new SqlConnection("Your connection string.")
    {
        dbConnection.Open();
        using (SqlCommand dbCommand = new SqlCommand(
          "select value from sys.configurations where name = 'backup compression default';", dbConnection))
        {
            // The values are:
            //   null  Backup compression is not supported.
            //   0     Backup compression is supported and disabled by default.
            //   1     Backup compression is supported and enabled by default.
            int? backupCompressionDefault = (int?)dbCommand.ExecuteScalar();
        }
        dbConnection.Close();
    }
