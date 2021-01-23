    Public Sub BatchUpdate(ByVal table1 As DataTable)
        Dim connectionStringServer2 As String = GetConnectionString()
    
        Using connection As New SqlConnection(connectionStringServer2)
            Dim adapter As New SqlDataAdapter()
    
            'Set the UPDATE command and parameters'
            adapter.UpdateCommand = New SqlCommand( _
              "UPDATE Table2 SET " _
              & "NAME=@NAME,Date=@Date  WHERE TableOneId=@TableOneId;", _
              connection)
            adapter.UpdateCommand.Parameters.Add("@Name", _
              SqlDbType.NVarChar, 50, "Name")
            adapter.UpdateCommand.Parameters.Add("@Date", _
              SqlDbType.DateTime, 0, "Date")
            adapter.UpdateCommand.Parameters.Add("@TableOneId", _
            SqlDbType.Int, 0, "TableOneId")
            adapter.UpdateCommand.UpdatedRowSource = _
              UpdateRowSource.None
    
            ' Set the batch size,' 
            ' try to update all rows in a single round-trip to the server'
            adapter.UpdateBatchSize = 0
    
            Dim table2 As New DataTable("table2")
            table2.Columns.Add(New DataColumn("Name", GetType(String)))
            table2.Columns.Add(New DataColumn("Date", GetType(Date)))
            table2.Columns.Add(New DataColumn("TableOneId", GetType(Int32)))
    
            ' copy content from table1 to table2'
            For Each row As DataRow In table1.Rows
                Dim newRow = table2.NewRow
                newRow("TableOneId") = row("ID")
                newRow("Name") = row("Name")
                newRow("Date") = row("Date")
                table2.Rows.Add(newRow)    
                ' note: i have not tested following, but it might work or give you a clue'
                newRow.AcceptChanges()
                newRow.SetModified()
            Next
            ' Execute the update'
            adapter.Update(table2)
        End Using
    End Sub
