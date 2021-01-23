    Option Explicit
    
    Public Event DeviceAdded(ByVal Device As UPNPLib.IUPnPDevice)
    Public Event DeviceRemoved(ByVal UDN As String)
    Public Event SearchComplete()
    
    Public Sub IDispatchCallback( _
        ByVal pDevice As Variant, _
        ByVal bstrUDN As Variant, _
        ByVal lType As Variant)
        'NOTE: Must be dispID = 0, i.e. the default method of the class.
    
        Select Case lType
            Case 0
                RaiseEvent DeviceAdded(pDevice)
            Case 1
                RaiseEvent DeviceRemoved(bstrUDN)
            Case 2
                RaiseEvent SearchComplete
        End Select
    End Sub
