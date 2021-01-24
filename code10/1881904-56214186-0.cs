Public Class Form1
    Dim outputQueue As New Queue(Of String)
    Dim captureAdapterID As Integer = 0
    Dim oProcess As Process
    Private Sub Button1_Click(sender1 As Object, e1 As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Button2.Enabled = True
        captureAdapterID = (ComboBox1.SelectedIndex + 1)
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender1 As Object, e1 As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            oProcess = New Process()
            Dim oStartInfo As New ProcessStartInfo("C:\Program Files\Wireshark\tshark.exe", " --print -l -i " & captureAdapterID & " -w ./sample.pcap -E separator=/t -T fields -e frame.number -e dns.qry.name src port 53")
            oStartInfo.WorkingDirectory = New Uri(System.Windows.Forms.Application.StartupPath).LocalPath
            oStartInfo.UseShellExecute = False
            oStartInfo.RedirectStandardOutput = True
            oStartInfo.RedirectStandardError = True
            oStartInfo.CreateNoWindow = True
            oStartInfo.WindowStyle = ProcessWindowStyle.Hidden
            oProcess.StartInfo = oStartInfo
            If oProcess.Start() Then
                appendOutput("Capturing on device: " & captureAdapterID & " started.")
                Dim sOutput As String
                Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
                    sOutput = oStreamReader.ReadLine
                    While Not sOutput Is Nothing
                        appendOutput(sOutput)
                        sOutput = oStreamReader.ReadLine
                    End While
                End Using
                Using oStreamReader As System.IO.StreamReader = oProcess.StandardError
                    sOutput = oStreamReader.ReadLine
                    While Not sOutput Is Nothing
                        appendOutput(sOutput)
                        sOutput = oStreamReader.ReadLine
                    End While
                End Using
                MsgBox("finished")
            Else
                MsgBox("Error starting the process")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            BackgroundWorker1.ReportProgress(10)
        End Try
    End Sub
    Private Sub appendOutput(sOutput As String)
        outputQueue.Enqueue(sOutput)
        BackgroundWorker1.ReportProgress(10)
    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Dim i As Integer = 0
        For i = 0 To outputQueue.Count - 1 Step 1
            RichTextBox1.AppendText(outputQueue.Dequeue & vbNewLine)
        Next
        RichTextBox1.ScrollToCaret()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        BackgroundWorker1.CancelAsync()
        oProcess.Kill()
        Button1.Enabled = True
        Button2.Enabled = False
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim process As New Process()
            Dim oStartInfo As New ProcessStartInfo("C:\Program Files\Wireshark\tshark.exe", " -D")
            oStartInfo.WorkingDirectory = New Uri(System.Windows.Forms.Application.StartupPath).LocalPath
            oStartInfo.UseShellExecute = False
            oStartInfo.RedirectStandardOutput = True
            oStartInfo.RedirectStandardError = True
            oStartInfo.CreateNoWindow = True
            oStartInfo.WindowStyle = ProcessWindowStyle.Hidden
            process.StartInfo = oStartInfo
            If process.Start() Then
                Dim sOutput As String
                Using oStreamReader As System.IO.StreamReader = process.StandardOutput
                    sOutput = oStreamReader.ReadToEnd
                    If Not sOutput Is Nothing Then
                        ComboBox1.Items.AddRange(sOutput.Trim.Split(vbNewLine))
                        Try
                            ComboBox1.SelectedIndex = 0
                        Catch ex As Exception
                        End Try
                    End If
                End Using
            Else
                MsgBox("Error starting the get adapter process failed")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
  
  [1]: https://osqa-ask.wireshark.org/questions/27357/how-to-pipe-tshark-output-in-realtime
  [2]: https://www.wireshark.org/docs/man-pages/tshark.html
