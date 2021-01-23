                Using con = New OracleConnection(cs)
                    con.Open()
                    Using cmd = con.CreateCommand()
                        cmd.CommandText = cmdText
                        cmd.Parameters.Add(pn, OracleDbType.NVarchar2, 250).Value = p
                        Dim tbl = New DataTable
                        Dim da = New OracleDataAdapter(cmd)
                        da.Fill(tbl)
                        Return tbl
                    End Using
                End Using
