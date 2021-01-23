    Public Class HIDController
        Implements IDisposable
    #Region "Constructor"
        Public Sub New(handle As IntPtr)
            If Not hidConnect(handle) Then
                'consider a custom exception type here.  You may also get
                'more info about the failure from GetLastError.
                Throw New Exception("Connection failed")
            End If
            _handle = handle
            _prevWinProc = DelegateSetWindowLong(handle, GWL_WNDPROC, AddressOf Me.WinProc)
        End Sub
    #End Region
    #Region "IDisposable Support"
        Private disposedValue As Boolean 
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                End If
                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                DisconnectFromHID()
            End If
            Me.disposedValue = True
        End Sub
        Protected Overrides Sub Finalize()
            Dispose(False)
            MyBase.Finalize()
        End Sub
        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
    #End Region
        Private _handle As IntPtr
        Private ReadOnly _prevWinProc As IntPtr
        'on one hand, you are not supposed to throw from Dispose/Finalize, but
        'on the other hand, I don't know what you would do instead to signal failure.
        Private Sub DisconnectFromHID()
            'do not disconnect if you did not connect
            If _handle = IntPtr.Zero Then Exit Sub
            If Not hidDisconnect() Then
                'see above about custom exception type
                Throw New Exception("Disconnect failed")
            End If
            SetWindowLong(_handle, GWL_WNDPROC, _prevWinProc)
            _handle = IntPtr.Zero
        End Sub
        Private Function WinProc(ByVal pHWnd As IntPtr, ByVal pMsg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
            If pMsg = WM_HID_EVENT Then
                Select Case wParam.ToInt32()
                    Case NOTIFY_PLUGGED
                        OnPlugged(lParam)
                    Case NOTIFY_UNPLUGGED
                        OnUnplugged(lParam)
                    Case NOTIFY_CHANGED
                        OnChanged()
                    Case NOTIFY_READ
                        OnRead(lParam)
                End Select
            End If
            WinProc = CallWindowProc(FPrevWinProc, pHWnd, pMsg, wParam, lParam)
        End Function
    #Region "USB events"
        Private Sub OnPlugged(lParam As IntPtr)
            RaiseEvent Plugged(Me, New ParamEventArgs(lParam))
        End Sub
        Public Event Plugged As EventHandler(Of ParamEventArgs)
        Private Sub OnUnplugged(lParam As IntPtr)
            RaiseEvent Unplugged(Me, New ParamEventArgs(lParam))
        End Sub
        Public Event Unplugged As EventHandler(Of ParamEventArgs)
        Private Sub OnChanged()
            RaiseEvent Changed(Me, EventArgs.Empty)
        End Sub
        Public Event Changed As EventHandler
        Private Sub OnRead(lParam As IntPtr)
            RaiseEvent Read(Me, New ParamEventArgs(lParam))
        End Sub
        Public Event Read As EventHandler(Of ParamEventArgs)
    #End Region
        'other constants and declarations I did not copy.
    End Class
    Public Class ParamEventArgs
        Inherits EventArgs
        Public Sub New(param As IntPtr)
            _param = param
        End Sub
        Private _param As IntPtr
        Public ReadOnly Property Param() As IntPtr
            Get
                Return _param
            End Get
        End Property
    End Class
