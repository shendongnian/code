    Class Flasher
        Private myDevice As New FlashLib.Device
        Private errMsg As String
    
        Public Function Flash() As String
            AddHandler myDevice.ErrorEvent, AddressOf OnError
            '... Do flashing stuff here that might send our `ErrorEvent` ...'
            If errMsg IsNot Nothing Then
                Throw New System.Exception(errMsg)
            End If
            myDevice.flash_firmware("myfirmware.fw")
            myDevice.restart()
            Threading.Thread.Sleep(5000)
            return "OK"
        End Function
    
        Public Sub OnError(ByRef Err As ErrEventArgs)
            errMsg = String.Format(
                "Device threw an error during flashing process. Type: {0}",
                Err.error)
        End Sub
