    Protected Overrides Sub OnFormClosing(e As System.Windows.Forms.FormClosingEventArgs)
      If e.Cancel Then
        e.Cancel = False
      End If
      MyBase.OnFormClosing(e)
    End Sub
