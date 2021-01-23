    ''' <summary>
    ''' Extends a WebException to include any body text from the HTTP Response in the .Message
    ''' </summary>
    Friend Function ExtendWebExceptionInfo(ex As Exception) As Exception
        Dim wEx As WebException = TryCast(ex, WebException)
        If wEx Is Nothing Then Return ex
        Dim exMessage As String = Nothing
        Using reader As New StreamReader(wEx.Response.GetResponseStream, System.Text.Encoding.UTF8)
            exMessage = reader.ReadToEnd
        End Using
        If Not String.IsNullOrWhiteSpace(exMessage) Then
            exMessage = String.Format("{0}{1}{1}The server says:{1}{2}", wEx.Message, vbCrLf, exMessage)
            Return New WebException(exMessage, wEx, wEx.Status, wEx.Response)
        End If
        Return wEx
    End Function
