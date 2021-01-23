    Option Explicit On
    Option Strict On
    
    Imports System.IO
    
    Public Class Form1
    
        Private TempFolder As String = Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, "Temp")
    
        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            CreateFiles()
    
            Dim Files = Directory.EnumerateFiles(TempFolder, "2010*.xml", SearchOption.TopDirectoryOnly).ToList()
            Using FS As New FileStream(Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, "Report.txt"), FileMode.Create, FileAccess.Write, FileShare.Read)
                Using SW As New StreamWriter(FS, System.Text.Encoding.ASCII)
                    For Each F In Files
                        SW.WriteLine(F)
                    Next
                End Using
            End Using
            
    
            DeleteFiles()
        End Sub
    
        Private Sub CreateFiles()
            If Not Directory.Exists(TempFolder) Then Directory.CreateDirectory(TempFolder)
            Dim Bytes() As Byte = {}
            Dim Name As String
            For Y = 2000 To 2010
                Trace.WriteLine(Y)
                For I = 1 To 5000
                    Name = String.Format("{0}_{1}.xml", Y, I.ToString.PadLeft(4, "0"c))
                    File.WriteAllBytes(Path.Combine(TempFolder, Name), Bytes)
                Next
            Next
        End Sub
        Private Sub DeleteFiles()
            Directory.Delete(TempFolder, True)
        End Sub
    End Class
