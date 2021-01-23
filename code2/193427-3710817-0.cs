    Friend Shared Function InternalGetIsNetworkAvailable() As Boolean
        If ComNetOS.IsWinNt Then
            Dim interface2 As NetworkInterface
            For Each interface2 In SystemNetworkInterface.GetNetworkInterfaces
                If (((interface2.OperationalStatus = OperationalStatus.Up) AndAlso (interface2.NetworkInterfaceType <> NetworkInterfaceType.Tunnel)) AndAlso (interface2.NetworkInterfaceType <> NetworkInterfaceType.Loopback)) Then
                    Return True
                End If
            Next
            Return False
        End If
        Dim flags As UInt32 = 0
        Return UnsafeWinINetNativeMethods.InternetGetConnectedState((flags), 0)
    End Function
    Private Shared Sub ChangedAddress(ByVal sender As Object, ByVal eventArgs As EventArgs)
        SyncLock AvailabilityChangeListener.syncObject
            Dim isNetworkAvailable As Boolean = SystemNetworkInterface.InternalGetIsNetworkAvailable
            If (isNetworkAvailable <> AvailabilityChangeListener.isAvailable) Then
                AvailabilityChangeListener.isAvailable = isNetworkAvailable
                Dim array As DictionaryEntry() = New DictionaryEntry(AvailabilityChangeListener.s_availabilityCallerArray.Count  - 1) {}
                AvailabilityChangeListener.s_availabilityCallerArray.CopyTo(array, 0)
                Dim i As Integer
                For i = 0 To array.Length - 1
                    Dim key As NetworkAvailabilityChangedEventHandler = DirectCast(array(i).Key, NetworkAvailabilityChangedEventHandler)
                    Dim context As ExecutionContext = DirectCast(array(i).Value, ExecutionContext)
                    If (context Is Nothing) Then
                        key.Invoke(Nothing, New NetworkAvailabilityEventArgs(AvailabilityChangeListener.isAvailable))
                    Else
                        ExecutionContext.Run(context.CreateCopy, AvailabilityChangeListener.s_RunHandlerCallback, key)
                    End If
                Next i
            End If
        End SyncLock
    End Sub
