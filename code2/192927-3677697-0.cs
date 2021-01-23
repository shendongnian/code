    Public Class Form1
        Private MyFolder As String = "C:\MyFolder\"
        Dim p As New PictureBox
        Dim w As New Microsoft.Office.Interop.Word.Application
        Dim x As New Microsoft.Office.Interop.Excel.Application
    
        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    
            For Each file In IO.Directory.GetFiles(MyFolder)
                ProcessFile(file)
            Next
        End Sub
    
        Sub ProcessFile(ByVal FileName As String)
            If TryJpeg(FileName) Then Exit Sub
            If TryWordDoc(FileName) Then Exit Sub
            If TryExcelDoc(FileName) Then Exit Sub    
        End Sub
    
        Function TryJpeg(ByVal Filename As String) As Boolean
    
            Try
                p.Image = Image.FromFile(MyFolder & Filename)
                'it worked, so we assume it is a picture, rename it to jpg.
                FileSystem.Rename(MyFolder & Filename, MyFolder & Filename & ".jpg")
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
    
        Function TryWordDoc(ByVal Filename As String) As Boolean
    
            Try
                w.Documents.Open(MyFolder & Filename)
                'it worked, so we assume it is a word document, rename it to docx.
                FileSystem.Rename(MyFolder & Filename, MyFolder & Filename & ".docx")
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
    
        Function TryExcelDoc(ByVal Filename As String) As Boolean
            Try
                x.Workbooks.Open(MyFolder & Filename)
                'it worked, so we assume it is a excel document, rename it to xlsx.
                FileSystem.Rename(MyFolder & Filename, MyFolder & Filename & ".xlsx")
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
    
    End Class
