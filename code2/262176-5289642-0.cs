    Dim sr As CSVDataReader
    Dim sbc As SqlClient.SqlBulkCopy
    sbc = New SqlClient.SqlBulkCopy(mConnectionString, SqlClient.SqlBulkCopyOptions.TableLock Or SqlClient.SqlBulkCopyOptions.KeepIdentity)
    sbc.DestinationTableName = "newTable"
    'sbc.BulkCopyTimeout = 0
    sr = New CSVDataReader(parentfileName, theBase64Map, ","c)
    sbc.WriteToServer(sr)
    sr.Close()
