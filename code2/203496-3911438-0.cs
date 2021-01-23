                Using dbConnection As New OracleConnection(OracleConnectionString)
                    'Open the connection
                    dbConnection.Open()
                    Dim dbCommand As OracleCommand = dbConnection.CreateCommand()
                    Dim dbTransaction As OracleTransaction
                    'Start a local transaction 
                    dbTransaction = dbConnection.BeginTransaction(IsolationLevel.ReadCommitted)
                    'Assign transaction object for a pending local transaction
                    dbCommand.Transaction = dbTransaction
                    Try
                        dbCommand.CommandType = CommandType.Text
                        dbCommand.CommandText = "UPDATE XXF_ASN_HEADERS SET BILL_OF_LADING_NUMBER ='" + BillOfLadingNumber + "', TRAILER_NUMBER ='" + TrailerNumber + "', CARRIER_CODE ='" + CarrierCode + "', TRANSPORTATION_METHOD ='" + TransportationMethod + "' WHERE HEADERID ='" + Request.QueryString("HeaderId") + "'"
                        dbCommand.ExecuteScalar()
                        dbTransaction.Commit()
                        Response.Redirect("default.aspx")
                    Catch ex As OracleException
                        'Rollback the transaction
                        dbTransaction.Rollback()
                        'display error details
                        lblUpdateQuery.Text = dbCommand.CommandText
                        lblDebug.Text = ex.Message.ToString
                    End Try
                End Using
