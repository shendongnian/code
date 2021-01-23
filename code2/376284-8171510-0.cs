    Private Const DEFAULT_SQL_SERVER_PORT As Integer = 1433
    Private m_SocketConnectedEvent As ManualResetEvent
    Private Function PingSQLServer(Optional ByVal wTimeoutSeconds As Integer = -1) As Boolean
        Dim theSocket As Socket = Nothing
        Dim theHostEntry As IPHostEntry
        Dim theEndPoint As IPEndPoint
        Dim dtStart As Date
        Dim theTimeSpan As TimeSpan
        Try
            ' Wait a second for the status, by default
            theTimeSpan = New TimeSpan(0, 0, 1)
            ' Get host related information.
            theHostEntry = Dns.Resolve(Me.MachineName)
            ' Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
            ' an exception that occurs when the host host IP Address is not compatible with the address family
            For Each theAddress As IPAddress In theHostEntry.AddressList
                dtStart = Now
                theEndPoint = Nothing
                theEndPoint = New IPEndPoint(theAddress, Me.PortNumber)
                theSocket = Nothing
                theSocket = New Socket(theEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
                m_SocketConnectedEvent = Nothing
                m_SocketConnectedEvent = New ManualResetEvent(False)
                ' Wait for a period of time to connect on this IP address/port combo
                ' If the connect succeeds, get out.
                theSocket.Blocking = False
                theSocket.Bind(New IPEndPoint(IPAddress.Any, 0))
                theSocket.BeginConnect(theEndPoint, AddressOf ConnectCallback, theSocket)
                Do
                    If m_SocketConnectedEvent.WaitOne(theTimeSpan, False) Then
                        Exit Do
                    End If
                    Me.IdleDelegate.Invoke(-1, True)
                    If wTimeoutSeconds <> -1 Then
                        If Now.Subtract(dtStart).TotalSeconds >= wTimeoutSeconds Then
                            Try
                                theSocket.Shutdown(SocketShutdown.Both)
                            Catch
                            End Try
                            Try
                                theSocket.Close()
                            Catch
                            End Try
                            theSocket = Nothing
                            Exit Do
                        End If
                    End If
                Loop
                If theSocket IsNot Nothing Then
                    If theSocket.Connected Then
                        Return True
                    End If
                End If
            Next
        Catch theException As Exception
            Call ReportError(theException)
        Finally
            If m_SocketConnectedEvent IsNot Nothing Then
                Try
                    m_SocketConnectedEvent.Close()
                Catch
                Finally
                    m_SocketConnectedEvent = Nothing
                End Try
            End If
            If theSocket IsNot Nothing Then
                Try
                    theSocket.Shutdown(SocketShutdown.Both)
                Catch
                End Try
                Try
                    theSocket.Close()
                Catch
                End Try
                theSocket = Nothing
            End If
        End Try
    End Function
    Private Sub ConnectCallback(ByVal ar As IAsyncResult)
        Try
            ' Retrieve the socket from the state object.
            Dim theClient As Socket
            theClient = DirectCast(ar.AsyncState, Socket)
            ' Complete the connection.
            If theClient IsNot Nothing Then
                theClient.EndConnect(ar)
            End If
        Catch theDisposedException As System.ObjectDisposedException
            ' Ignore this error
        Catch theSocketException As SocketException
            Select Case theSocketException.ErrorCode
                ' Connection actively refused
                Case 10061
                    ' Don't report the error; it's just that SQL Server isn't answering.
                Case Else
                    Call ReportError(theSocketException)
            End Select
        Catch theException As Exception
            Call ReportError(theException)
        Finally
            ' Signal that the connection has been made.
            If m_SocketConnectedEvent IsNot Nothing Then
                m_SocketConnectedEvent.Set()
            End If
        End Try
    End Sub
