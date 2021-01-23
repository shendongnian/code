    Option Explicit
    'Requires reference to:
    '
    '   UPnP 1.0 Type Library (Control Point)
    '
    
    Private Const CONN_SVCTYPEID_URI As String = "urn:schemas-upnp-org:service:WANIPConnection:1"
    Private Const CONN_ID_URI As String = "urn:upnp-org:serviceId:WANIPConn1"
    
    Private UDFinder As UPNPLib.UPnPDeviceFinder
    Private WithEvents UNCBs As UPnPNATCBs
    Private findData As Long
    Private blnSuccess As Boolean
    
    Public Event Result(ByVal Success As Boolean, ByVal FriendlyName As String, ByVal IP As String)
    
    Public Sub Fetch()
        blnSuccess = False
        Set UDFinder = New UPNPLib.UPnPDeviceFinder
        Set UNCBs = New UPnPNATCBs
        findData = CallByName(UDFinder, "CreateAsyncFind", VbMethod, CONN_SVCTYPEID_URI, 0, UNCBs)
        UDFinder.StartAsyncFind findData
    End Sub
    
    Private Sub UNCBs_DeviceAdded(ByVal Device As UPNPLib.IUPnPDevice)
        Dim Services As UPNPLib.UPnPServices
        Dim Service As UPNPLib.UPnPService
        Dim varInActionArgs, varOutActionArgs
        Dim strFriendlyName As String
        Dim strIP As String
        
        strFriendlyName = Device.FriendlyName
        On Error Resume Next
        Set Services = Device.Services
        If Err.Number = 0 Then
            On Error GoTo 0
            With Services
                If .Count > 0 Then
                    On Error Resume Next
                    Set Service = .Item(CONN_ID_URI)
                    If Err.Number = 0 Then
                        On Error GoTo 0
                        ReDim varInActionArgs(0 To 0)
                        ReDim varOutActionArgs(0 To 0)
                        Service.InvokeAction "GetExternalIPAddress", _
                                             varInActionArgs, _
                                             varOutActionArgs
                        strIP = varOutActionArgs(0)
                        blnSuccess = True
                    Else
                        On Error GoTo 0
                    End If
                End If
            End With
        Else
            On Error GoTo 0
        End If
        
        UDFinder.CancelAsyncFind findData
        RaiseEvent Result(blnSuccess, strFriendlyName, strIP)
        Set UDFinder = Nothing
        Set UNCBs = Nothing
    End Sub
    
    Private Sub UNCBs_SearchComplete()
        If Not blnSuccess Then
            RaiseEvent Result(False, "", "")
        End If
    End Sub
