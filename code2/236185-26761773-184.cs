    Dim dr As SqlDataReader
    Try
        Dim lnk As LinkButton = TryCast(sender, LinkButton)
        Dim gr As GridViewRow = DirectCast(lnk.NamingContainer, GridViewRow)
        Dim eid As String = GridView1.DataKeys(gr.RowIndex).Value.ToString()
        ViewState("username") = eid
        sqlQry = "select FirstName, Surname, DepartmentName, ExtensionName, jobTitle,
                 Pager, mailaddress, from employees1 where username='" & eid & "'"
        If connection.State <> ConnectionState.Open Then
            connection.Open()
        End If
        command = New SqlCommand(sqlQry, connection)
        'More code fooing and barring
        dr = command.ExecuteReader()
        If dr.Read() Then
            lblFirstName.Text = Convert.ToString(dr("FirstName"))
            ...
        End If
        mpe.Show()
    Catch
    Finally
        command.Dispose()
        dr.Close()             ' <-- NRE
        connection.Close()
    End Try
