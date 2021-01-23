    Friend Function ApiWebRequest(ByVal method As String, ByVal url As String, ByVal fileRequest As OAuthFileRequest) As String
    
            Dim request As HttpWebRequest = Me.GenerateCoreWebRequest(url, method)
    
            request.Headers.Add("Authorization", Me.GetAuthHeaderValue(New Uri(url), method))
    
            Select Case Me.ApiType
    
                Case OAuthApiType.Twitter
                    Me.PrepareTwitterDataRequest(request, fileRequest)
    
                Case OAuthApiType.LinkedIn
                    Me.PrepareLinkedInDataRequest(request, fileRequest)
    
                Case OAuthApiType.Other
                    Me.PrepareDataRequest(request, fileRequest)
    
            End Select
    
            Return Me.ProcessWebRequest(request)
    
        End Function
    
        Private Sub PrepareTwitterDataRequest(ByRef request As HttpWebRequest, ByVal fileRequest As OAuthFileRequest)
    
            Dim shortFileName As String = fileRequest.FileShortName
    
            Dim fileContentType As String = Me.GetMimeType(shortFileName)
    
            Dim message As String = fileRequest.Message
    
            Dim encoding As Text.Encoding = Text.Encoding.GetEncoding("iso-8859-1")
    
            Dim fileHeader As String = String.Format("Content-Disposition: file; " & "name=""media""; filename=""{0}""", shortFileName)
    
            Dim boundary As String = DateTime.Now.Ticks.ToString("x")
    
            Dim separator As String = String.Format("--{0}", boundary)
    
            Dim footer As String = String.Format("\r\n{0}--\r\n", separator)
    
            Dim contents As New Text.StringBuilder()
    
            contents.AppendLine(separator)
            contents.AppendLine("Content-Disposition: form-data; name=""status""")
            contents.AppendLine()
            contents.AppendLine(message)
            contents.AppendLine(separator)
            contents.AppendLine(fileHeader)
            contents.AppendLine(String.Format("Content-Type: {0}", fileContentType))
            contents.AppendLine()
    
            Dim contentsBuffer As Byte() = encoding.GetBytes(contents.ToString())
    
            Dim footBuffer As Byte() = encoding.GetBytes(footer)
    
            'collect all byte() into one stream
            Dim byteCollector As New MemoryStream
            byteCollector.Write(contentsBuffer, 0, contentsBuffer.Length)
            byteCollector.Write(fileRequest.FileData, 0, fileRequest.FileData.Length)
            byteCollector.Write(footBuffer, 0, footBuffer.Length)
    
            'dump collector stream into byte()
            Dim requestBytes As Byte() = byteCollector.ToArray()
    
            'close/dispose the collector
            byteCollector.Close()
            byteCollector.Dispose()
    
            request.ContentType = (String.Format("multipart/form-data; boundary=""{0}""", boundary))
            request.ContentLength = requestBytes.Length
    
            Using reqStream As IO.Stream = request.GetRequestStream()
    
                reqStream.Write(requestBytes, 0, requestBytes.Length)
    
            End Using
    
        End Sub
