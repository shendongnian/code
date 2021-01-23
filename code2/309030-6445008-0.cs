    Dim conn As New MySqlConnection
    Dim myCommand As New MySqlCommand
    Dim myAdapter As New MySqlDataAdapter
    Dim myData As New DataTable
    Dim SQL As String
    
    conn.ConnectionString = myConnString
    conn.Open()
    
    myCommand.Connection = conn
    myCommand.CommandText = SQL
    
    myAdapter.SelectCommand = myCommand
    myAdapter.Fill(myData)
