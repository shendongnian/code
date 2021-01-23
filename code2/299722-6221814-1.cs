    Public WM_SYSCOMMAND As Integer = &H112
    Public SC_MONITORPOWER As Integer = &Hf170
    <DllImport("user32.dll")> _
    Private Shared Function SendMessage(hWnd As Integer, hMsg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function
    
    Private Sub button1_Click(sender As Object, e As System.EventArgs)
    	SendMessage(Me.Handle.ToInt32(), WM_SYSCOMMAND, SC_MONITORPOWER, 2)
    End Sub
