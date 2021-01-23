    Public Class Form1
    
        Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
            End ''// use a flag if you would like a more graceful way to handle this. 
        End Sub
    
        WithEvents ucProgress As New Progress   ''// just doing it this way so I don''//t have to paste designer code.
    
        Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
            Controls.Clear()
            Controls.Add(ucProgress)
            Me.ucProgress.pb.Visible = False
            ucProgress.StartProgress()
            Try
                ucProgress.Message = "Starting up..."
                Application.DoEvents()
                Me.ucProgress.pb.Visible = True
                Me.ucProgress.pb.Maximum = 21
                Me.ucProgress.pb.Value = 0
    
                For i As Integer = 0 To 20
                    Dim btn As New Button
    
                    btn.Top = +i * 3
                    btn.Left = i * 8
                    btn.Text = CStr(i)
                    btn.Enabled = False ''// ONLY HAVE TO DO FOR CTLS RIGHT ON MAIN FORM
                    ucProgress.EnabledStates.Add(btn, True)  ''// ONLY HAVE TO DO FOR CTLS RIGHT ON MAIN FORM
                    Controls.Add(btn)
                    btn.BringToFront()
    
                    System.Threading.Thread.Sleep(200)
                    Application.DoEvents()
    
                    ucProgress.pb.Value += 1
                    ucProgress.Message = "Processing item# " & i.ToString
                    If Me.ucProgress.Cancel Then
                        MsgBox("Cancelled - not all loaded.")
                        Me.ucProgress.Cancel = False
                        Exit For
                    End If
                Next
    
    
            Catch ex As Exception
                MsgBox(ex.ToString, , "Error loading something")
            Finally
                ucProgress.EndProgress()
            End Try
        End Sub
    End Class
