    Imports Microsoft.VisualBasic.ApplicationServices
    
    Namespace My
      Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
          If e.CommandLine.Count > 0 AndAlso e.CommandLine.Item(0).Equals("/min", StringComparison.InvariantCultureIgnoreCase) Then
            Application.MainForm = New Form1 With {.NoActivate = True, .WindowState = FormWindowState.Minimized}
          End If
        End Sub
      End Class
    End Namespace
