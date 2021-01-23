    Public Sub SetTitle(ByVal Title As String)
        Dim h As New HandleRef(Me, Handle)
        SendMessage(h, WM_SETTEXT, 0, Title)
    End Sub
    Public Function GetTitle() As String
        Dim str As String = String.Empty
        Dim h As New HandleRef(Me, Handle)
        SendMessage(h, WM_GETTEXT, 300, str)
        Return str
    End Function
