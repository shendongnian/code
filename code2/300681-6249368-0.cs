    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        _Context = context
        _Context.Response.Clear()
        _Context.Response.ContentType = "image/jpg"
        If ImageParameter IsNot Nothing Then
            Dim imageData As Byte() = Nothing
            If String.IsNullOrEmpty(ImageParameter.CompressedFileStorageLocation) Then
                Return
            End If
            Dim imagePath As String = String.Format("{0}{1}", CS_IMAGE_REPOSITORY_BASE_PATH, ImageParameter.CompressedFileStorageLocation)
            Try
                If IO.File.Exists(imagePath) Then
                    Using s As FileStream = New FileStream(imagePath, FileMode.Open)
                        ReDim imageData(s.Length)
                        Dim bytesRead As Integer = s.Read(imageData, 0, s.Length)
                        s.Close()
                    End Using
                End If
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
            _Context.Response.OutputStream.Write(imageData, 0, imageData.Length)
        End If
    End Sub
