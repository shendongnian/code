    Private Function RunElevated(commandLine As String, Optional ByVal timeout As Integer = 0) As Boolean
        Dim startInfo As New ProcessStartInfo
        startInfo.UseShellExecute = True
        startInfo.WorkingDirectory = Environment.CurrentDirectory
        Dim uri As New Uri(Assembly.GetEntryAssembly.GetName.CodeBase)
        startInfo.FileName = uri.LocalPath
        startInfo.Verb = "runas"
        startInfo.Arguments = commandLine
        Dim success As Boolean
        Try
            Dim p As Process = Process.Start(startInfo)
            ' wait thirty seconds for completion
            If timeout > 0 Then
                If Not p.WaitForExit(30000) Then
                    ' did not complete in thirty seconds, so kill
                    p.Kill()
                    success = False
                Else
                    success = True
                End If
            Else
                p.WaitForExit()
                success = True
            End If
        Catch ex As Win32Exception
            success = False
        Catch ex As Exception
            MsgBox("Error occurred while trying to start application as administrator: " & ex.Message)
            success = False
        End Try
        Return success
    End Function
    Public Function IsAdmin() As Boolean
        Dim id As WindowsIdentity = WindowsIdentity.GetCurrent
        Dim p As New WindowsPrincipal(id)
        Return p.IsInRole(WindowsBuiltInRole.Administrator)
    End Function
