    ' arp -s 192.168.1.12 01-02-03-04-05-06
    Public Sub UpdateArpTable(IpAddress as string, MacAddress as string)
        Dim outputMessage As string = ""
        Dim errorMessage As string = ""
        Dim command As String = String.Format("-s {0} {1}", Address, MacAddress)
        ExecuteShellCommand("arp", command, outputMessage, errorMessage)
    End Sub
    Public Shared Sub ExecuteShellCommand(FileToExecute As String, CommandLine As String)
	    Dim Process As System.Diagnostics.Process = Nothing
	    Try
		    Process = New System.Diagnostics.Process()
		    Dim CMDProcess As String = String.Format("{0}\cmd.exe", Environment.SystemDirectory)
		    Dim Arguments As String = String.Format("/C {0}", FileToExecute)
		    If CommandLine IsNot Nothing AndAlso CommandLine.Length > 0 Then
			    Arguments += String.Format(" {0}", CommandLine)
		    End If
		    Dim ProcessStartInfo As New System.Diagnostics.ProcessStartInfo(CMDProcess, Arguments)
		    ProcessStartInfo.CreateNoWindow = True
		    ProcessStartInfo.UseShellExecute = False
		    ProcessStartInfo.RedirectStandardOutput = True
		    ProcessStartInfo.RedirectStandardInput = True
		    ProcessStartInfo.RedirectStandardError = True
		    Process.StartInfo = ProcessStartInfo
		    Process.Start()
		    Process.WaitForExit()
		    Process.WaitForExit()
	    Finally
		    ' close process and do cleanup
		    Process.Close()
		    Process.Dispose()
		    Process = Nothing
	    End Try
    End Sub
