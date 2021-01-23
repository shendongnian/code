    Imports System.IO
    Public Class Form1
    Dim lstFiles As List(Of String) = New List(Of String)
    Private Sub DirSearch(path As String)
        Dim thingies = From file In Directory.GetFiles(path) Where file.EndsWith(".doc") Select file
        lstFiles.AddRange(thingies)
        For Each subdir As String In Directory.GetDirectories(path)
            DirSearch(subdir)
        Next
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        FolderBrowserDialog1.ShowDialog()
        If Not String.IsNullOrEmpty(FolderBrowserDialog1.SelectedPath) Then
            lstFiles.Clear()
            DirSearch(FolderBrowserDialog1.SelectedPath)
            Dim word As New Microsoft.Office.Interop.Word.Application
            Dim doc As Microsoft.Office.Interop.Word.Document
            lstFiles.RemoveAll(Function(y) y.Contains(".docx"))
            Dim startTime As DateTime = DateTime.Now
            Debug.Print("Timer started at " & DateTime.Now().ToString & Environment.NewLine)
            For Each x In lstFiles
                word.Visible = False
                Debug.Print(x + Environment.NewLine)
                doc = word.Documents.Open(x)
                doc.Convert()
                doc.Close()
            Next
            word.Quit()
            Dim endTime As DateTime = DateTime.Now
            Debug.Print("Took " & endTime.Subtract(startTime).TotalSeconds & " to process " & lstFiles.Count & " documents" & Environment.NewLine)
        End If
    End Sub
    End Class
