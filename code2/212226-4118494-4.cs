    Public Class Form1
    
    
        ' That's our custom TextWriter class
        Private _writer As System.IO.TextWriter = Nothing
    
        Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If p IsNot Nothing Then
                p.Close()
                p.Dispose()
                p = Nothing
            End If
        End Sub
    
    
        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            InitProcess()
            '' Instantiate the writer
            '_writer = New ConsoleRedirection.TextBoxStreamWriter(Me.txtConsole)
            '' Redirect the out Console stream
            'Console.SetOut(_writer)
            'Console.WriteLine("Now redirecting output to the text box1")
            'Console.WriteLine("Now redirecting output to the text box2")
        End Sub
    
        Protected p As Process
        Protected sw As System.IO.StreamWriter
        Protected sr As System.IO.StreamReader
        Protected err As System.IO.StreamReader
    
    
        Protected objWriter As System.IO.StreamWriter
        Protected objWriteNumeric As System.IO.StreamWriter
    
        Private Sub InitProcess()
            p = New Process()
    
            Dim psI As New ProcessStartInfo("cmd")
            psI.UseShellExecute = False
            psI.RedirectStandardInput = True
            psI.RedirectStandardOutput = True
            psI.RedirectStandardError = True
            psI.CreateNoWindow = True
            p.StartInfo = psI
            p.Start()
            sw = p.StandardInput
            sr = p.StandardOutput
            err = p.StandardError
            sw.AutoFlush = True
    
    
            objWriter = New System.IO.StreamWriter("c:\temp\logmy.txt", True, System.Text.Encoding.ASCII)
            objWriteNumeric = New System.IO.StreamWriter("c:\temp\lognum.txt", True, System.Text.Encoding.ASCII)
    
    
    
            Timer1.Enabled = True
            Timer1.Start()
    
        End Sub
    
        Private Sub start()
    
            If Me.txtinput.Text <> "" Then
                sw.WriteLine(Me.txtinput.Text)
            Else
                'execute default command
                sw.WriteLine("dir c:\music")
            End If
            sw.Flush()
    
            Timer2.Enabled = True
        End Sub
    
    
        Private Sub start_original()
            p = New Process()
            Dim sw As System.IO.StreamWriter
            Dim sr As System.IO.StreamReader
            Dim err As System.IO.StreamReader
            Dim psI As New ProcessStartInfo("cmd")
            psI.UseShellExecute = False
            psI.RedirectStandardInput = True
            psI.RedirectStandardOutput = True
            psI.RedirectStandardError = True
            psI.CreateNoWindow = True
            p.StartInfo = psI
            p.Start()
            sw = p.StandardInput
            sr = p.StandardOutput
            err = p.StandardError
            sw.AutoFlush = True
    
            Me.txtinput.Text = "help"
    
            If Me.txtinput.Text <> "" Then
                sw.WriteLine(Me.txtinput.Text)
            Else
                'execute default command
                sw.WriteLine("dir \")
            End If
            sw.Close()
    
    
    
            'Me.txtConsole.Text = sr.ReadToEnd()
    
            'txtinput.Text = sr.ReadToEnd()
            'txtinput.Text += err.ReadToEnd()
        End Sub
    
    
    
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            start()
        End Sub
    
    
    
    
        Protected sb As String = ""
        Sub ReadOutputStreamIfAvailable()
            'cbEndOfStream.Checked = sr.EndOfStream
    
            While True
                objWriteNumeric.WriteLine(sr.Peek().ToString())
                objWriteNumeric.Flush()
    
    
    
                If sr.Peek = -1 Then
                    Exit While
                End If
    
    
                Dim iCharAsNumber As Integer = sr.Read()
    
                Dim cNumberAsChar As Char = Nothing
                If Not iCharAsNumber = Nothing Then
                    Try
                        cNumberAsChar = Chr(iCharAsNumber)
                    Catch
                        Continue While
                        'MsgBox(Prompt:=xx.ToString, Title:="Error")
                        'Exit While
                    End Try
    
                End If
    
                Dim strCharAsString As String = ""
                If Not cNumberAsChar = Nothing Then
                    strCharAsString = cNumberAsChar.ToString()
                End If
    
                sb += strCharAsString
            End While
    
    
            If Not String.IsNullOrEmpty(sb) Then
                'MsgBox(sb)
                MsgBox(sb)
                Me.txtConsole.Text += sb
                'MsgBox(sb)
                sb = ""
            End If
        End Sub
    
    
    
    
    
    
        Protected er As String = ""
        Sub ReadErrorStreamIfAvailable()
            'cbEndOfStream.Checked = sr.EndOfStream
    
            While True
                objWriteNumeric.WriteLine(sr.Peek().ToString())
                objWriteNumeric.Flush()
    
    
                If err.Peek = -1 Then
                    Exit While
                End If
    
    
                Dim iCharAsNumber As Integer = err.Read()
    
                Dim cNumberAsChar As Char = Nothing
                If Not iCharAsNumber = Nothing Then
                    Try
                        cNumberAsChar = Chr(iCharAsNumber)
                    Catch
                        Continue While
                        'MsgBox(Prompt:=xx.ToString, Title:="Error")
                        'Exit While
                    End Try
    
                End If
    
                Dim strCharAsString As String = ""
                If Not cNumberAsChar = Nothing Then
                    strCharAsString = cNumberAsChar.ToString()
                End If
    
                er += strCharAsString
            End While
    
    
            If Not String.IsNullOrEmpty(er) Then
                'MsgBox(sb)
                'MsgBox(er)
                Me.txtConsole.Text += er
                'MsgBox(sb)
                er = ""
            End If
        End Sub
    
    
    
        Protected Shared objOutputStreamLocker As Object = New Object
    
        Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
            Timer1.Enabled = False
    
            SyncLock objOutputStreamLocker
                ReadOutputStreamIfAvailable()
                'ReadErrorStreamIfAvailable()
            End SyncLock
    
            Timer1.Enabled = True
        End Sub
    
    
        Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
            Try
                Timer2.Enabled = False
                sb = Chr(sr.Read()).ToString()
                ''
                'er = Chr(err.Read()).ToString()
                ''
    
                Timer1.Enabled = True
            Catch ex As Exception
                MsgBox("You have terminated the process", Title:="You idiot!")
            End Try
        End Sub
    
    
        ' http://www.c-sharpcorner.com/UploadFile/edwinlima/SystemDiagnosticProcess12052005035444AM/SystemDiagnosticProcess.aspx
        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    
        End Sub
    
    
    End Class
