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
        Dim OleDbSQL As String = _
            "SELECT RIGHT('000000000000000' + TRIM(" & firstColumnName & "),15) AS IMEI " & _
            "FROM [" & firstWorkSheet & "] " & _
            "WHERE LEN(TRIM(" & firstColumnName & ")) BETWEEN 10 AND 15 " & _
            "ORDER BY " & firstColumnName
        Dim OleDbCmd As OleDbCommand = New OleDbCommand(OleDbSQL, connection)
        Dim OleDbAdapter As New OleDbDataAdapter(OleDbCmd)
        Dim tblWorkSheet As New DataTable
        OleDbAdapter.Fill(tblWorkSheet)
        Using bulkCopy As New SqlBulkCopy(sSqlConnectionString)
            bulkCopy.DestinationTableName = destTable
            bulkCopy.WriteToServer(tblWorkSheet)
        End Using
    End Using
