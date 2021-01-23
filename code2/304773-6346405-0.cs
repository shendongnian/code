    Private Sub tProgress_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tProgress.Tick
            Count = (Count + 1) Mod ProgressBar1.Maximum
            ProgressBar1.Value = Count
        End Sub
    Public Sub KillMe(ByVal o As Object, ByVal e As EventArgs)
    
            Me.Close()
    
        End Sub
