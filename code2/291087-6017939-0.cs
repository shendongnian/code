    <System.Web.Services.WebMethod> _
    <System.Web.Script.Services.ScriptMethod> _
    Public Shared Function GetUploadStatus() As Object
    	Dim info As UploadDetail = DirectCast(HttpContext.Current.Session("UploadDetail"), UploadDetail)
    	If info IsNot Nothing AndAlso info.IsReady Then
    		Dim soFar As Integer = info.UploadedLength
    		Dim total As Integer = info.ContentLength
    		Dim percentComplete As Integer = CInt(Math.Ceiling(CDbl(soFar) / CDbl(total) * 100))
    		Dim message As String = "Uploading..."
    		Dim fileName As String = String.Format("{0}", info.FileName)
    		Dim downloadBytes As String = String.Format("{0} of {1} Bytes", soFar, total)
    		Return New With { _
    			Key .percentComplete = percentComplete, _
    			Key .message = message, _
    			Key .fileName = fileName, _
    			Key .downloadBytes = downloadBytes _
    		}
    	End If
    	Return Nothing
    End Function
