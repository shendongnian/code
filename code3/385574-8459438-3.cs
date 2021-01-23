    Imports System.Web
    Imports System.IO
    Imports System.Net
    Imports System.IO.Compression
    
    Namespace RiderDesign.FrameworkV4.HttpModule
    
        Public NotInheritable Class HttpCompressionModule
            Implements IHttpModule
            Private Shared GZIP As String = "gzip"
            Private Shared DEFLATE As String = "deflate"
    
            Private Shared ENCODING_TYPE As String = "encodingType"
            Private Shared CONTENT_TYPE As String = "contentType"
            Private MARK As String = "passedModule"
            Dim HttpState As HttpCompressionConfigStateModule
            Sub Dispose() Implements IHttpModule.Dispose
            End Sub
            Sub Init(ByVal context As HttpApplication) Implements IHttpModule.Init
    
                If HttpCompressionConfigModule.GetConfig().CompressionOn = True Then
                    ' Use for any other then WebResource
                    AddHandler context.PostReleaseRequestState, AddressOf context_PostReleaseRequestState
                End If
    
                If HttpCompressionConfigModule.GetConfig().CompressionOn = True Then
                    ' Use only for WebResource.axd files
                    AddHandler context.BeginRequest, AddressOf context_BeginRequest
                    AddHandler context.EndRequest, AddressOf context_EndRequest
                End If
            End Sub 'IHttpModule.Init
    
            Sub context_PostReleaseRequestState(ByVal sender As Object, ByVal e As EventArgs)
                Dim app As HttpApplication = CType(sender, HttpApplication) '
    
                If TypeOf app.Context.CurrentHandler Is System.Web.UI.Page And app.Request("HTTP_X_MICROSOFTAJAX") Is Nothing Then
                    Dim FilePath As String
                    Dim FilePaths As List(Of String) = New List(Of String)
    
                    For Each Me.HttpState In HttpCompressionConfigModule.GetConfig().ExcludedFilePaths
                        FilePaths.Add(String.Format("{0}", HttpState.Value))
                    Next HttpState
                    FilePath = String.Join(", ", FilePaths.ToArray())
    
                    Dim ContentTypes As String
                    Dim FileTypes As List(Of String) = New List(Of String)
                    Dim state As HttpCompressionConfigStateModule
                    For Each state In HttpCompressionConfigModule.GetConfig().IncludedFileTypes
                        FileTypes.Add(String.Format("{0}", state.Value))
                    Next state
                    ContentTypes = String.Join(", ", FileTypes.ToArray())
    
    
                    ' Check if the path is not excluded.
                    If FilePath.Contains(app.Request.AppRelativeCurrentExecutionFilePath) Then
                        Return
                    End If
                    ' Check if the mime type is not excluded. (Use to exclude pages that generate specific mime type (such image or Excel...))
                    If Not ContentTypes.Contains(app.Response.ContentType) Then
                        Return
                    End If
                    ' Check if GZIP is supported by the client
                    If IsGzipEncodingSupported() Then
                        app.Response.Filter = New GZipStream(app.Response.Filter, CompressionMode.Compress)
                        SetEncodingType(GZIP)
                        ' Check if DEFLATE is supported by the client 
    
                    Else
                        If IsDeflateEncodingSupported() Then
                            app.Response.Filter = New DeflateStream(app.Response.Filter, CompressionMode.Compress)
                            SetEncodingType(DEFLATE)
                        End If
                    End If
                End If
            End Sub
    
    
            Sub context_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
                Dim app As HttpApplication = CType(sender, HttpApplication) '
                '
                ' Check if the current request is WebResource.axd
                If app.Request.Path.Contains("WebResource.axd") Then
                    SetCachingHeaders(app)
    
                    If app.Context.Request.QueryString(MARK) Is Nothing Then
                        app.CompleteRequest()
                    End If
                End If
            End Sub 'context_BeginRequest
    
    
    
            Sub context_EndRequest(ByVal sender As Object, ByVal e As EventArgs)
                Dim app As HttpApplication = CType(sender, HttpApplication) '
    
                If app.Request.Path.Contains("WebResource.axd") And app.Context.Request.QueryString(MARK) Is Nothing Then
                    Dim cacheKey As String = app.Request.QueryString.ToString()
    
                    If app.Application(cacheKey) Is Nothing Then
                        CompressedIntoCache(app, cacheKey)
                    End If
    
                    SetEncodingType(CStr(app.Application((cacheKey + ENCODING_TYPE))))
                    app.Context.Response.ContentType = CStr(app.Application((cacheKey + CONTENT_TYPE)))
                    app.Context.Response.BinaryWrite(CType(app.Application(cacheKey), Byte()))
                End If
            End Sub 'context_EndRequest
    
    
    
            Private Sub CompressedIntoCache(ByVal app As HttpApplication, ByVal cacheKey As String)
                'Mark the current request by adding QueryString parameter.
                Dim request As HttpWebRequest = CType(WebRequest.Create((app.Context.Request.Url.OriginalString + "&" + MARK + "=1")), HttpWebRequest)
                request.Credentials = CredentialCache.DefaultNetworkCredentials
                Using response As HttpWebResponse = CType(request.GetResponse, HttpWebResponse)
    
                    If (True) Then
                        ' We getting the response stream, that raise again the 'BeginRequest' event (that why we marked the request)
                        Dim responseStream As Stream = response.GetResponseStream()
    
                        Dim contentType As String = response.ContentType.ToLower()
    
                        ' Not a javascript or css content.
                        ' We compress only WebResources that are Javascript or css file.
                        ' The problem is, that we can know the content type only after we got the response. TODO: find a better solution
                        ' for non CSS or JS content
                        If Not IsContentSupported(contentType) Then
                            ' Set the response type
                            app.Context.Response.ContentType = contentType
    
                            ' Send the file to the client without compression
                            StreamCopy(responseStream, app.Response.OutputStream)
                            responseStream.Dispose()
                            app.Context.Response.End()
                            Return
                        End If
    
                        ' Copy the response stream into memory stream, so we can convert it into byte[] easly.
                        Dim dataStream As New MemoryStream()
                        StreamCopy(responseStream, dataStream)
                        responseStream.Dispose()
    
                        ' Convert the response into byte[]
                        Dim data As Byte() = dataStream.ToArray()
                        dataStream.Dispose()
                        Dim encodingType As String = String.Empty
    
                        Using memstream As MemoryStream = New MemoryStream
                            Dim compress As Stream = Nothing
    
                            ' Choose the compression type and make the compression
                            If IsGzipEncodingSupported() Then
                                compress = New GZipStream(memstream, CompressionMode.Compress)
                                encodingType = GZIP
                            Else
                                If IsDeflateEncodingSupported() Then
                                    compress = New DeflateStream(memstream, CompressionMode.Compress)
                                    encodingType = DEFLATE
                                End If
                            End If
                            compress.Write(data, 0, data.Length)
                            compress.Dispose()
    
                            app.Application.Lock()
                            app.Application.Add(cacheKey, memstream.ToArray())
                            app.Application.Add(cacheKey + ENCODING_TYPE, encodingType)
                            app.Application.Add(cacheKey + CONTENT_TYPE, response.ContentType)
                            app.Application.UnLock()
    
                        End Using
                    End If
                End Using
    
            End Sub 'CompressedIntoCache
    
    
    
    
            Private Shared Sub StreamCopy(ByVal input As Stream, ByVal output As Stream)
                Dim buffer(2048) As Byte
                Dim read As Integer
                Do
                    read = input.Read(buffer, 0, buffer.Length)
                    output.Write(buffer, 0, read)
                Loop While read > 0
            End Sub 'StreamCopy
    
            Private Shared Sub SetCachingHeaders(ByVal app As HttpApplication)
                Dim etag As String = """" + app.Context.Request.QueryString.ToString().GetHashCode().ToString() + """"
                Dim incomingEtag As String = app.Request.Headers("If-None-Match")
    
                app.Response.Cache.VaryByHeaders("Accept-Encoding") = True
                app.Response.Cache.SetExpires(DateTime.Now.ToUniversalTime().AddDays(365))
                app.Response.Cache.SetCacheability(HttpCacheability.Public)
                app.Response.Cache.SetLastModified(DateTime.Now.ToUniversalTime().AddDays(-1))
                app.Response.Cache.SetETag(etag)
    
                If [String].Compare(incomingEtag, etag) = 0 Then
                    app.Response.StatusCode = CInt(HttpStatusCode.NotModified)
                    app.Response.End()
                End If
            End Sub 'SetCachingHeaders
    
    
            Private Shared Function IsBrowserSupported() As Boolean
                ' Because bug in Internet Explorer 6
                Return Not (HttpContext.Current.Request.UserAgent Is Nothing Or HttpContext.Current.Request.UserAgent.Contains("MSIE 6"))
            End Function 'IsBrowserSupported
    
    
            Private Shared Function IsEncodingSupported() As Boolean
                Return IsGzipEncodingSupported() Or IsDeflateEncodingSupported()
            End Function 'IsEncodingSupported
    
            Private Shared Function IsGzipEncodingSupported() As Boolean
                Return Not (HttpContext.Current.Request.Headers("Accept-encoding") Is Nothing) And HttpContext.Current.Request.Headers("Accept-encoding").Contains(GZIP)
            End Function 'IsGzipEncodingSupported
    
            Private Shared Function IsDeflateEncodingSupported() As Boolean
                Return Not (HttpContext.Current.Request.Headers("Accept-encoding") Is Nothing) And HttpContext.Current.Request.Headers("Accept-encoding").Contains(DEFLATE)
            End Function 'IsDeflateEncodingSupported
    
            Private Shared Sub SetEncodingType(ByVal encoding As String)
                HttpContext.Current.Response.AppendHeader("Content-encoding", encoding)
            End Sub 'SetEncodingType
    
            Private Shared Function IsContentSupported(ByVal contentType As String) As Boolean
                If contentType.Contains("text/css") Or contentType.Contains("javascript") Then
                    Return True
                End If
                Return False
            End Function
        End Class
    End Namespace
