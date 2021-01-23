    Partial Class ClientBase
    Private Const intSize As Int32 = 4
    Private Shared ReadOnly _SC As SynchronizationContext = SynchronizationContext.Current
    Private _incomingData As Byte() = New Byte() {}
    Private _objectDataLength As Nullable(Of Int32)
    Private Sub StartReceive()
        Dim receiveBuffer(8 * 1024 - 1) As Byte
        Try
            TcpClient.Client.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, AddressOf DataReceived, receiveBuffer)
        Catch
            DropConnection()
        End Try
    End Sub
    Private Sub DataReceived(ByVal ar As IAsyncResult)
        If _disconnected Then Return
        Dim dataRead As Int32
        Try
            dataRead = TcpClient.Client.EndReceive(ar)
        Catch
            DropConnection()
            Return
        End Try
        If dataRead = 0 Then
            DropConnection()
            Return
        End If
        Dim byteData = DirectCast(ar.AsyncState, Byte())
        'Copy the received data to the internal buffer.
        _incomingData = _incomingData.Append(byteData.Take(dataRead).ToArray())
        If _objectDataLength.HasValue Then
    1:      If _incomingData.Length >= _objectDataLength.Value Then
                Dim data As Object
                Using ms As New IO.MemoryStream(_incomingData, 0, _objectDataLength.Value)
                    Dim bf As New BinaryFormatter()
                    Try
                        data = bf.Deserialize(ms)
                    Catch
                        DropConnection()
                        Return
                    End Try
                End Using
                'Invoke in DataReceived in sync context.
                _SC.Post(Sub(T As Object)
                             Try
                                 DataReceived(T)
                             Catch
                                 Stop 'For new delegate thing in vb check. Remove when first time stopped.
                                 DropConnection()
                             End Try
                         End Sub, data)
                'Cut first _objectDataLength bytes from the internal buffer.
                _incomingData = _incomingData.TrimLeft(_objectDataLength.Value)
                _objectDataLength = Nothing
                GoTo 2
            End If
        Else
    2:      If _incomingData.Length >= intSize Then
                _objectDataLength = BitConverter.ToInt32(_incomingData.TakeLeft(intSize), 0)
                'Cut first four bytes from the internal buffer.
                _incomingData = _incomingData.TrimLeft(intSize)
                GoTo 1
            End If
        End If
        StartReceive()
    End Sub
    Private Sub DropConnection()
        _disconnected = True
        Me.Dispose()
        'Raise disconnection event in sync thread.
        _SC.Post(Sub()
                     RaiseEvent Disconnect(Me)
                 End Sub, Nothing)
    End Sub
    End Class
