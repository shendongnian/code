    <%@ WebHandler Language="C#" Class="handlerExample" %>
    using System;
    using System.Web;
    using iTextSharp.text;  
    using iTextSharp.text.pdf;
    
    public class handlerExample : IHttpHandler {
      public void ProcessRequest (HttpContext context) {
        HttpResponse Response = context.Response;
        Response.ContentType = "application/pdf";
        Response.AddHeader(
          "Content-disposition", 
          "attachment; filename=Construct2-Manual-Full.pdf"
        );  
        using (Document document = new Document()) {
          PdfWriter.GetInstance(
            document, Response.OutputStream
          );
          document.Open();
          document.Add(new Paragraph("Hello World!"));
        }
      }
      public bool IsReusable { get { return false; } }
    }
