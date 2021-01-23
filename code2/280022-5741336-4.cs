    Public Function GetWebPage(ByVal URL As String) As String
    	Dim Request As System.Net.HttpWebRequest = CType(WebRequest.Create(New Uri(URL)), HttpWebRequest)
    	With Request
    		.Method = "GET"
    		.MaximumAutomaticRedirections = 4
    		.MaximumResponseHeadersLength = 4
    		.ContentLength = 0
    	End With
    
    	Dim ReadStream As StreamReader = Nothing
    	Dim Response As HttpWebResponse = Nothing
    	Dim ResponseText As String = String.Empty
    
    	Try
    		Response = CType(Request.GetResponse, HttpWebResponse)
    		Dim ReceiveStream As Stream = Response.GetResponseStream
    		ReadStream = New StreamReader(ReceiveStream, System.Text.Encoding.UTF8)
    		ResponseText = ReadStream.ReadToEnd
    		Response.Close()
    		ReadStream.Close()
    
    	Catch ex As Exception
    		ResponseText = String.Empty
    	End Try
    
    	Return ResponseText
    End Function
