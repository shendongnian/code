     query = "Insert Into jobs (jobname,daterecieved,custid) Values ('" & ProjectNAme & "','" & FormatDateTime(Now, DateFormat.ShortDate) & "'," & Me.CustomerID.EditValue & ");"'Select Scope_Identity()"
            ' Using cn As New SqlConnection(connect)
              Using cmd As New OleDb.OleDbCommand(query, cnPTA)
                    cmd.Parameters.AddWithValue("@CategoryName", OleDb.OleDbType.Integer)
                    If cnPTA.State = ConnectionState.Closed Then cnPTA.Open()
                    ID = cmd.ExecuteNonQuery
              End Using
