    ...
        WcfStream test = new WcfStream();
        test.SQLStream = new SqlFileStream(filePath, txContext, FileAccess.Read);
        test.StreamClosedEventHandler +=
                    new EventHandler((sender, args) => DownloadStreamCompleted(sqlDataReader, sqlConnection));
        return test;
    }
    private void DownloadStreamCompleted(SqlDataReader sqlDataReader, SQLConnection sqlConnection)
    {
        // You might want to commit Transaction here as well
        sqlDataReader.Close();
        sqlConnection.Close();
    }
