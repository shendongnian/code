    Public Shared Sub RemoveWatermark(path As String, savePath As String)
      Using reader = New PdfReader(path)
        Using fs As New FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None)
          Using stamper As New PdfStamper(reader, fs)
            Using remover As New PdfLayerRemover(reader)
              remover.RemoveByName("WatermarkLayer")
            End Using
          End Using
        End Using
      End Using
    End Sub
