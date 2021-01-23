    Namespace SQL
    
    
        Public Class MS_SQL
    
            Public Const strDefaultCatalog As String = "COR_Basic"
    
    
            Public Shared Function GetConnectionString(Optional ByRef strIntitialCatalog As String = strDefaultCatalog) As String
                
                Return strConnectionString
            End Function ' GetConnectionString
    
    
            Public Shared Function GetConnection(ByVal strConnectionString As String)
                'GetConnectionString(strDataBaseName)
    
                Return New System.Data.SqlClient.SqlConnection(strConnectionString)
            End Function
    
    
            Public Shared Function GetConnection() As System.Data.IDbConnection
                Static strConnectionString As String = GetConnectionString()
    
                Return New System.Data.SqlClient.SqlConnection(strConnectionString)
            End Function ' GetConnection
    
    
            Public Shared Function TestConnection() As Boolean
                Dim bExceptionOccured As Boolean = False
    
                Using dbConnection As System.Data.IDbConnection = GetConnection()
    
                    SyncLock dbConnection
    
                        Try
                            'Console.WriteLine("Connection timout: " + dbConnection.ConnectionTimeout.ToString)
                            If Not dbConnection.State = ConnectionState.Open Then
                                dbConnection.Open()
                            End If
                        Catch ex As Exception
                            bExceptionOccured = True
                            'Log.File.WriteText("Error opening the database connection. Check your connection string and password as well as networking and permissions.")
                            Log.File.WriteText("Fehler beim Öffnen der Datenbankverbindung. Bitte überprüfen Sie den Verbindungsstring und das Passwort, sowie das Netzwerk und Berechtigungen.")
                            'Log.File.WriteText("Exception message:")
                            Log.File.WriteText("Fehlerbeschreibung:")
                            Console.WriteLine(ex.Message)
                            ErrorHandling.Exception.iExitCode = ErrorHandling.Exception.ExitCode.EXIT_DATABASE_NOCONNECT
                            'MsgBox("Connection couldn't be opened.", MsgBoxStyle.Critical)
                            ErrorHandling.Exception.TerminateWithErrorcode(ErrorHandling.Exception.ExitCode.EXIT_DATABASE_NOCONNECT)
                        Finally
                            If Not dbConnection.State = ConnectionState.Closed Then
                                dbConnection.Close()
                            End If
                        End Try
    
                    End SyncLock ' dbConnection
    
                End Using ' dbConnection
    
                Return bExceptionOccured
            End Function ' TestConnection
    
    
            Public Shared Function GetEmbeddedSQLscript(ByVal strSearchedFileName As String) As String
                Dim ass As System.Reflection.Assembly = System.Reflection.Assembly.GetAssembly(GetType(MS_SQL))
    
                If String.IsNullOrEmpty(strSearchedFileName) Then
                    Throw New ArgumentNullException("strSearchedFileName")
                End If
    
                Dim strFoundRessourceName As String = Nothing
                For Each strEmbeddedRessourceName As String In ass.GetManifestResourceNames()
                    If Not String.IsNullOrEmpty(strEmbeddedRessourceName) Then
    
                        If strEmbeddedRessourceName.EndsWith(strSearchedFileName, System.StringComparison.OrdinalIgnoreCase) Then
                            strFoundRessourceName = strEmbeddedRessourceName
                            Exit For
                        End If
                        ' Console.WriteLine(strEmbeddedRessourceName)
                    End If
                Next
    
                If String.IsNullOrEmpty(strFoundRessourceName) Then
                    Throw New Exception("The script """ + strSearchedFileName + """ is not present in the embedded ressources section.")
                Else
                    'Console.WriteLine(strFoundRessourceName)
                End If
    
                Dim strSQLscript As String = Nothing
                Try
                    Using strmRessource As System.IO.Stream = ass.GetManifestResourceStream(strFoundRessourceName)
    
                        Using srRessourceReader As New System.IO.StreamReader(strmRessource)
                            strSQLscript = srRessourceReader.ReadToEnd()
                            srRessourceReader.Close()
                        End Using
    
                        strmRessource.Close()
                    End Using
                Catch ex As Exception
                    Throw
                End Try
    
                Return strSQLscript
            End Function ' GetEmbeddedSQLscript
    
    
            Public Class cParameterStore
    
                Public Class cParameter
                    Public SqlDbType As System.Data.SqlDbType = Nothing
                    Protected m_Value As Object = Nothing
    
    
                    Public Sub New(ByVal dbt As System.Data.SqlDbType, ByVal objValue As Object)
                        Me.SqlDbType = dbt
                        Me.Value = objValue
                    End Sub ' Constructor
    
    
                    Public Property Value() As Object
    
                        Get
                            Return Me.m_Value
                        End Get
    
                        Set(ByVal objValue As Object)
                            If objValue IsNot Nothing Then
                                Me.m_Value = objValue
                            Else
                                Me.m_Value = System.DBNull.Value
                            End If
                        End Set
    
                    End Property ' Value
    
                End Class ' cParameter
    
    
                Public m_dictParameters As Dictionary(Of String, cParameter) = Nothing
    
    
                Sub New()
                    Me.m_dictParameters = New Dictionary(Of String, cParameter)
                End Sub ' Constructor
    
    
                Public ReadOnly Property Parameters() As Dictionary(Of String, cParameter)
    
                    Get
                        Return Me.m_dictParameters
                    End Get
    
                End Property ' Parameters
    
    
                Public Sub Add(ByVal strKey As String, ByVal dbt As System.Data.SqlDbType, ByVal objValue As Object)
                    If String.IsNullOrEmpty(strKey) Then
                        Throw New ArgumentNullException("strKey")
                    End If
    
                    If dbt = Nothing Then
                        Throw New ArgumentNullException("dbt")
                    End If
    
                    If Not strKey.StartsWith("@") Then
                        strKey = "@" + strKey
                    End If
    
                    m_dictParameters.Add(strKey, New cParameter(dbt, objValue))
                End Sub ' Add
    
            End Class ' cParameterStore
    
    
            Public Shared Function GetNewParamterStore() As cParameterStore
                Return New cParameterStore()
            End Function ' GetNewParamterStore
    
    
    
            Public Shared Sub ExecuteSQLreader(ByRef strSQL As String, ByRef strWhich As String, ByRef alSQLqueryReturnList As ArrayList)
                'Dim alSQLqueryReturnList As ArrayList
                'alSQLqueryReturnList = New ArrayList
    
                Using dbConn As System.Data.IDbConnection = GetConnection()
    
                    SyncLock dbConn
    
                        Using sqlCMD As System.Data.IDbCommand = dbConn.CreateCommand()
    
                            Try
                                sqlCMD.CommandText = strSQL
    
                                If Not dbConn.State = System.Data.ConnectionState.Open Then
                                    dbConn.Open()
                                End If
    
                                Using sdrSQLReader As System.Data.IDataReader = sqlCMD.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
                                    While sdrSQLReader.Read()
                                        alSQLqueryReturnList.Add(sdrSQLReader.Item(strWhich).ToString())
                                    End While
                                End Using
    
                            Catch QueryError As Exception
                                'Log.File.WriteText(String.Format("Exception in ExecuteSQLreader: {0}{1}{2}", QueryError.Message, vbCrLf, strSQL))
                                Log.File.WriteText(String.Format("Fehler in ExecuteSQLreader: {0}{1}{2}", QueryError.Message, vbCrLf, strSQL))
                            Finally
                                If Not dbConn.State = System.Data.ConnectionState.Closed Then
                                    dbConn.Close()
                                End If
                            End Try
    
                        End Using ' sqlCMD
    
                    End SyncLock ' dbConn
    
                End Using ' dbConn
    
            End Sub ' ExecuteSQLreader
    
    
            Public Shared Function ExecuteSQLstmtScalarWithParameter(ByRef strSQL As String, ByVal ParameterStore As cParameterStore) As String
                Dim strReturnValue As String = ""
    
                Using sqldbConnection As System.Data.IDbConnection = GetConnection()
    
                    SyncLock sqldbConnection
    
                        Using sqlCMD As System.Data.SqlClient.SqlCommand = sqldbConnection.CreateCommand()
                            sqlCMD.CommandText = strSQL
    
                            Try
                                'sqlCMD.Parameters.Add("@mandant", System.Data.SqlDbType.Int).Value = 5
                                For Each kvpThisParameter As KeyValuePair(Of String, cParameterStore.cParameter) In ParameterStore.Parameters
                                    sqlCMD.Parameters.Add(kvpThisParameter.Key, kvpThisParameter.Value.SqlDbType).Value = kvpThisParameter.Value.Value
                                Next
    
    
                                ' Open the connection
                                If Not sqldbConnection.State = ConnectionState.Open Then
                                    sqldbConnection.Open()
                                End If
    
                                Dim objResult As Object = sqlCMD.ExecuteScalar()
    
                                If objResult IsNot Nothing Then
                                    strReturnValue = objResult.ToString()
                                Else
                                    strReturnValue = Nothing
                                End If
    
                                objResult = Nothing
                            Catch ex As System.Data.SqlClient.SqlException
                                'Log.File.WriteText(String.Format("Exception executing ExecuteSQLstmtScalarWithParameter: {0}", ex.Message.ToString() + vbCrLf + "strSQL=" + strSQL))
                                Log.File.WriteText(String.Format("Fehler beim Ausführen von ExecuteSQLstmtScalarWithParameter: {0}", ex.Message.ToString() + vbCrLf + "strSQL=" + strSQL))
                                ' No Error notification when silent
                            Finally
    
                                ' Open the connection
                                If Not sqldbConnection.State = ConnectionState.Closed Then
                                    sqldbConnection.Close()
                                End If
    
                                sqlCMD.Dispose()
                                sqldbConnection.Dispose()
                            End Try
    
                        End Using ' sqlCMD
    
                    End SyncLock ' sqldbConnection
    
                End Using ' sqldbConnection
    
                Return strReturnValue
            End Function ' ExecuteSQLstmtScalarWithParameter
    
    
            Public Shared Function ExecuteSQLstmtScalar(ByRef strSQL As String) As String
                Dim strReturnValue As String = ""
    
                Using sqldbConnection As System.Data.IDbConnection = GetConnection()
    
                    SyncLock sqldbConnection
    
                        Using sqlCMD As SqlClient.SqlCommand = sqldbConnection.CreateCommand()
                            sqlCMD.CommandText = strSQL
    
                            Try
                                ' Open the connection
                                If Not sqldbConnection.State = ConnectionState.Open Then
                                    sqldbConnection.Open()
                                End If
    
                                Dim objResult As Object = sqlCMD.ExecuteScalar()
    
                                If objResult IsNot Nothing Then
                                    strReturnValue = objResult.ToString()
                                Else
                                    strReturnValue = Nothing
                                End If
    
                                objResult = Nothing
                            Catch ex As System.Data.SqlClient.SqlException
                                'Log.File.WriteText(String.Format("Exception executing ExecuteSQLstmtScalar: {0}", ex.Message.ToString() + vbCrLf + "strSQL=" + strSQL))
                                Log.File.WriteText(String.Format("Fehler beim Ausführen von ExecuteSQLstmtScalar: {0}", ex.Message.ToString() + vbCrLf + "strSQL=" + strSQL))
                                ' No Error notification when silent
                            Finally
    
                                ' Open the connection
                                If Not sqldbConnection.State = ConnectionState.Closed Then
                                    sqldbConnection.Close()
                                End If
    
                                sqlCMD.Dispose()
                                sqldbConnection.Dispose()
                            End Try
    
                        End Using ' sqlCMD
    
                    End SyncLock ' sqldbConnection
    
                End Using ' sqldbConnection
    
                Return strReturnValue
            End Function ' ExecuteSQLstmtScalar
    
    
    
            Public Shared Sub ExecuteSQLStmtWithParameters(ByRef strSQL As String, ByVal ParameterStore As cParameterStore)
    
                Using conn As System.Data.IDbConnection = GetConnection()
    
                    SyncLock conn
                        Using sqlCMD As System.Data.SqlClient.SqlCommand = conn.CreateCommand
                            sqlCMD.CommandText = strSQL
                            'sqlCMD.Parameters.Add("@mandant", System.Data.SqlDbType.Int).Value = 5
                            For Each kvpThisParameter As KeyValuePair(Of String, cParameterStore.cParameter) In ParameterStore.Parameters
                                sqlCMD.Parameters.Add(kvpThisParameter.Key, kvpThisParameter.Value.SqlDbType).Value = kvpThisParameter.Value.Value
                            Next
    
                            'Dim x As System.Data.IDataParameter = cmd.CreateParameter()
                            'x.ParameterName = ""
                            'x.Value = ""
                            'sqlCMD.Parameters.Add(x)
    
    
                            Try
                                ' Open the connection
                                If Not conn.State = ConnectionState.Open Then
                                    conn.Open()
                                End If
    
                                sqlCMD.ExecuteNonQuery()
    
                                'Log.File.WriteText(String.Format("Command ExecuteSQLStmtWithParameters completed successfully. {0}", vbCrLf + "strSQL=" + strSQL))
                            Catch ex As SqlClient.SqlException
                                'Log.File.WriteText(String.Format("Exception executing ExecuteSQLStmtWithParameters: {0}", ex.Message.ToString() + vbCrLf + "strSQL=" + strSQL))
                                Log.File.WriteText(String.Format("Fehler beim Ausführen von ExecuteSQLStmtWithParameters: {0}", ex.Message.ToString() + vbCrLf + "strSQL=" + strSQL))
                            Finally
                                If Not conn.State = ConnectionState.Closed Then
                                    conn.Close()
                                End If
                            End Try
    
                        End Using ' sqlCMD
    
                    End SyncLock ' conn
    
                End Using ' conn
    
            End Sub ' ExecuteSQLStmtWithParameters
    
    
            Public Shared Sub ExecuteSQLStmtNoNotification(ByRef strSQL As String, Optional ByRef strConnectionString As String = Nothing)
                Using conn As System.Data.IDbConnection = GetConnection()
    
                    SyncLock conn
    
                        Using cmd As System.Data.IDbCommand = conn.CreateCommand()
                            cmd.CommandText = strSQL
    
                            Try
                                ' Open the connection
                                If Not conn.State = ConnectionState.Open Then
                                    conn.Open()
                                End If
    
                                cmd.ExecuteNonQuery()
                                'Log.File.WriteText(String.Format("Command ExecuteSQLStmtNoNotification completed successfully. {0}", vbCrLf + "strSQL=" + strSQL))
                            Catch ex As SqlClient.SqlException
                                'Log.File.WriteText(String.Format("Exception executing ExecuteSQLStmtNoNotification: {0}", ex.Message.ToString() + vbCrLf + "strSQL=" + strSQL))
                                Log.File.WriteText(String.Format("Fehler beim Ausführen von ExecuteSQLStmtNoNotification: {0}", ex.Message.ToString() + vbCrLf + "strSQL=" + strSQL))
                            Finally
                                If Not conn.State = ConnectionState.Closed Then
                                    conn.Close()
                                End If
                            End Try
    
                        End Using ' cmd
    
                    End SyncLock ' conn
    
                End Using ' conn
    
            End Sub 'ExecuteSQLStmtNoNotification
    
    
    
            Public Shared Function ExecuteSQLStmtNoNotificationReturnError(ByRef strSQL As String, Optional ByRef strConnectionString As String = Nothing) As System.Data.SqlClient.SqlException
                Dim eErrorCatcher As System.Data.SqlClient.SqlException = Nothing
    
                Using conn As System.Data.IDbConnection = GetConnection()
    
                    SyncLock conn
    
                        Using sqlCMD As System.Data.IDbCommand = conn.CreateCommand()
    
                            Try
                                sqlCMD.CommandText = strSQL
    
                                ' Open the connection
                                If Not conn.State = System.Data.ConnectionState.Open Then
                                    conn.Open()
                                End If
    
                                sqlCMD.ExecuteNonQuery()
                            Catch ex As System.Data.SqlClient.SqlException
                                eErrorCatcher = ex
                                Log.File.WriteText(String.Format("Fehler beim Ausführen von ExecuteSQLStmtNoNotificationReturnError: {0}", ex.Message.ToString() + vbCrLf + "strSQL=" + strSQL))
                            Catch ex As Exception
                                Log.File.WriteText(String.Format("Unerwarteter Fehler beim Ausführen von ExecuteSQLStmtNoNotificationReturnError: {0}", ex.Message.ToString() + vbCrLf + "strSQL=" + strSQL))
                            Finally
                                If Not conn.State = System.Data.ConnectionState.Closed Then
                                    conn.Close()
                                End If
                            End Try
    
                        End Using ' sqlCMD
    
                    End SyncLock ' conn
    
                End Using ' conn
    
                Return eErrorCatcher
            End Function 'ExecuteSQLStmtNoNotificationReturnError
    
    
            Public Shared Sub ExecuteSQLStmtSilent(ByRef strSQL As String)
                Using conn As System.Data.IDbConnection = GetConnection()
    
                    SyncLock conn
    
                        Using cmd As System.Data.IDbCommand = conn.CreateCommand()
                            cmd.CommandText = strSQL
                            Try
                                ' Open the connection
                                If Not conn.State = ConnectionState.Open Then
                                    conn.Open()
                                End If
    
                                cmd.ExecuteNonQuery()
                            Catch ex As System.Data.SqlClient.SqlException
                                ' No Error notification in silent mode
                                'Log.File.WriteText(String.Format("Exception executing ExecuteSQLStmtSilent: {0}", ex.Message.ToString() + vbCrLf + "strSQL=" + strSQL))
                                Log.File.WriteText(String.Format("Fehler beim Ausführen von ExecuteSQLStmtSilent: {0}", ex.Message.ToString() + vbCrLf + "strSQL=" + strSQL))
                            Finally
                                ' Open the connection
                                If Not conn.State = ConnectionState.Closed Then
                                    conn.Close()
                                End If
                            End Try
    
                        End Using ' cmd
    
                    End SyncLock ' conn
    
                End Using ' conn
    
            End Sub 'ExecuteSQLStmtSilent
    
    
            Public Shared Sub GetDataSetWithParameters(ByRef strSQL As String, ByRef dsDataFromTable As DataSet, ByRef ParameterStore As cParameterStore)
                GetDataSetWithParameters(strSQL, dsDataFromTable, "ThisTable", ParameterStore)
            End Sub ' GetDataSetWithParameters
    
    
            Public Shared Sub GetDataSetWithParameters(ByRef strSQL As String, ByRef dsDataFromTable As DataSet, ByVal strTableName As String, ByRef ParameterStore As cParameterStore)
                Using sqlConnection As System.Data.SqlClient.SqlConnection = GetConnection()
    
                    SyncLock sqlConnection
    
                        Using sqlCMD As System.Data.SqlClient.SqlCommand = sqlConnection.CreateCommand()
                            sqlCMD.CommandText = strSQL
                            'sqlCMD.Parameters.Add("@mandant", System.Data.SqlDbType.Int).Value = 5
                            Try
                                For Each kvpThisParameter As KeyValuePair(Of String, cParameterStore.cParameter) In ParameterStore.Parameters
                                    sqlCMD.Parameters.Add(kvpThisParameter.Key, kvpThisParameter.Value.SqlDbType).Value = kvpThisParameter.Value.Value
                                Next
                            Catch ex As Exception
                                Log.File.WriteText(String.Format("Fehler in GetDataSetWithParameters (at adding parameters): {0}", ex.Message + Environment.NewLine + "strSQL=" + strSQL))
                            End Try
    
                            Using daQueryTable As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(sqlCMD)
                                Try
    
    
    
                                    dsDataFromTable = New System.Data.DataSet(strTableName)
    
                                    If Not sqlConnection.State = System.Data.ConnectionState.Open Then
                                        sqlConnection.Open()
                                    End If
    
                                    daQueryTable.Fill(dsDataFromTable)
                                Catch ex As Exception
                                    'Log.File.WriteText(String.Format("Exception executing GetDataSetWithParameters: {0}", ex.Message + vbCrLf + "strSQL=" + strSQL))
                                    Log.File.WriteText(String.Format("Fehler in GetDataSetWithParameters: {0}", ex.Message + Environment.NewLine + "strSQL=" + strSQL))
                                Finally
                                    If Not sqlConnection.State = System.Data.ConnectionState.Closed Then
                                        sqlConnection.Close()
                                    End If
                                End Try
    
                            End Using ' daQueryTable
    
                        End Using ' sqlCMD
    
                    End SyncLock ' sqlConnection
    
                End Using ' sqlConnection
    
            End Sub ' GetDataSetWithParameters
    
    
            Public Shared Sub GetDataSet(ByRef strSQL As String, ByRef dsDataFromTable As DataSet)
                GetDataSet(strSQL, dsDataFromTable, "ThisTable")
            End Sub ' GetDataSetWithParameters
    
    
            Public Shared Sub GetDataSet(ByRef strSQL As String, ByRef dsDataFromTable As DataSet, ByVal strTableName As String)
                Using sqlConnection As System.Data.SqlClient.SqlConnection = GetConnection()
    
                    SyncLock sqlConnection
    
                        Using daQueryTable As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(strSQL, sqlConnection)
                            Try
                                dsDataFromTable = New System.Data.DataSet(strTableName)
    
                                If Not sqlConnection.State = System.Data.ConnectionState.Open Then
                                    sqlConnection.Open()
                                End If
    
                                daQueryTable.Fill(dsDataFromTable)
                            Catch ex As Exception
                                'Log.File.WriteText(String.Format("Exception executing GetDataSetWithParameters: {0}", ex.Message.ToString() + vbCrLf + "strSQL=" + strSQL))
                                Log.File.WriteText(String.Format("Fehler in GetDataSetWithParameters: {0}", ex.Message + Environment.NewLine + "strSQL=" + strSQL))
                            Finally
                                If Not sqlConnection.State = System.Data.ConnectionState.Closed Then
                                    sqlConnection.Close()
                                End If
                            End Try
    
                        End Using ' daQueryTable
    
                    End SyncLock ' sqlConnection
    
                End Using ' sqlConnection
    
            End Sub ' GetDataSet
    
    
    
        End Class
    
    
    End Namespace
