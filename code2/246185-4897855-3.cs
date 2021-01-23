    Using connection As New OleDbConnection(sExcelConnectionString)
        connection.Open()
        Dim schemaTable As DataTable = _
            connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, _
            New Object() {Nothing, Nothing, Nothing, "TABLE"})
        Dim schemaColTable As DataTable = _
            connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, _
            New Object() {Nothing, Nothing, Nothing, Nothing})
        Dim firstWorkSheet As String = schemaTable.Rows(0)("TABLE_NAME").ToString
        Dim firstColumnName As String = schemaColTable.Rows(0)("COLUMN_NAME").ToString
        Dim OleDbSQL As String = String.Format( _
            "SELECT TRIM([{1}]) AS IMEI " & _
            "FROM [{0}] " & _
            "WHERE LEN(TRIM([{1}])) BETWEEN 10 AND 15 " & _
            "ORDER BY [{1}]", firstWorkSheet, firstColumnName)
        Dim OleDbCmd As OleDbCommand = New OleDbCommand(OleDbSQL, connection)
        Using bulkCopy As New SqlBulkCopy(sSqlConnectionString)
             bulkCopy.DestinationTableName = destTable
             bulkCopy.WriteToServer(OleDbCmd.ExecuteReader)
        End Using
    End Using
