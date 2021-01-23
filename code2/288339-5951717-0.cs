    Dim WithEvents sp As New IO.Ports.SerialPort
    Private Sub sp_PinChanged(sender As Object, _
                              e As System.IO.Ports.SerialPinChangedEventArgs) Handles sp.PinChanged
        'look at e.EventType or check states
        Select Case True
            Case sp.CDHolding
            Case sp.CtsHolding
            Case sp.DsrHolding
            Case sp.RtsEnable
            Case e.EventType = IO.Ports.SerialPinChange.Ring
        End Select
    End Sub
