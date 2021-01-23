    Response.ContentType = "message/rfc822" 
    Dim ByteDocBlob() As Byte = cwWebUtil.ConvertLocalFileToByteArray(FilePath, True)
    Dim HTMLText As String = System.Text.Encoding.UTF8.GetString(ByteDocBlob)
    Response.Write(HTMLText)
    Response.End()
