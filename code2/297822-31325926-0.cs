    ' in whatever class you do your database communication:
    Private _database As SqlDatabase
    Private Shared _schema As DataTable
    Sub New()
      ' or however you handle the connection string / database creation
      Dim connectionString as String = GetConnectionString()
      _database = New SqlDatabase(connectionString)
      
      RetrieveSchema()
    End Sub
    Private Function RetrieveSchema() as DataTable
      If _schema Is Nothing Then
        Using connection As SqlConnection = _database.CreateConnection()
          connection.Open()
          _schema = connection.GetSchema("Columns")
        End Using
      End If
      return _schema
    End Function
    Public Function GetColumnInformation(tableName As String, columnName As String) as DataRow
      Dim firstMatchingRow as DataRow = (
        From row In _schema.Rows _
        Where (
          row("TABLE_NAME") = tableName AndAlso row("COLUMN_NAME") = columnName)
        )).FirstOrDefault()
    
      Return firstMatchingRow
    End Function
