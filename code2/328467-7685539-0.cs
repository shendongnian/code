    Public Class Form1
    
        Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
            Dim filepath As String = "c:\database.txt"
    
            Dim filestream As System.IO.FileStream
    
            Dim count As Int32
    
            For count = 0 To System.Int32.MaxValue
                filestream = New System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read)
                AppendLog(count, filestream.ReadByte)
            Next
        End Sub
    
        Private LogFilepath As String = "C:\LogInfo.txt"
        Private Enter As String = Chr(13) & Chr(10)
        Private Space As String = " "
    
        Private Sub AppendLog(ByVal Sequence As Int32, ByVal info As Byte)
            System.IO.File.AppendAllText(LogFilepath, Enter & Sequence & Space & CStr(info))
        End Sub
    
    End Class
