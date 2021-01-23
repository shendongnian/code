                Using bu2 As New SqlCommand(sqlStmt, SqlConnection1)
                    SqlConnection1.Open()
                    bu2.CommandTimeout = 180   //this line is the key
                    bu2.ExecuteNonQuery()
                    SqlConnection1.Close()
                End Using
            End Using
