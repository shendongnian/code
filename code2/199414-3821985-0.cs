    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If e.Equals(EventArgs.Empty) Then
            ' Performclick
        Else
            ' Normal click
        End If
    End Sub
    
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button1.PerformClick()
    End Sub
