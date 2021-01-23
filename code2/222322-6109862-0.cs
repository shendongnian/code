    <%@ WebHandler Language="VB" Class="upload" %>
    
    Imports System
    Imports System.IO
    Imports System.Web
    
    
    Public Class upload : Implements IHttpHandler
        
     
        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
            Dim chunk As Integer = If(context.Request("chunk") IsNot Nothing, Integer.Parse(context.Request("chunk")), 0)
            Dim fileName As String = If(context.Request("name") IsNot Nothing, context.Request("name"), String.Empty)
    
            Dim fileUpload As HttpPostedFile = context.Request.Files(0)
    
            Dim uploadPath = context.Server.MapPath("~/uploads")
            Using fs = New FileStream(Path.Combine(uploadPath, fileName), If(chunk = 0, FileMode.Create, FileMode.Append))
                Dim buffer = New Byte(fileUpload.InputStream.Length - 1) {}
                fileUpload.InputStream.Read(buffer, 0, buffer.Length)
    
                fs.Write(buffer, 0, buffer.Length)
            End Using
    
            context.Response.ContentType = "text/plain"
            context.Response.Write("Success")
        End Sub
    
        Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
            Get
                Return False
            End Get
        End Property
    
    End Class
 
 
