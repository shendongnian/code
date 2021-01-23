    <%@ WebHandler Language="C#" Class="lockPdf" %>
    using System;
    using System.Web;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    public class lockPdf : IHttpHandler {
      public void ProcessRequest (HttpContext context) {
        HttpServerUtility Server = context.Server;
        HttpResponse Response = context.Response;
        Response.ContentType = "application/pdf";
        using (Document document = new Document()) {
          PdfWriter writer = PdfWriter.GetInstance(
            document, Response.OutputStream
          );
          writer.SetEncryption(
    // null user password => users can open document __without__ pasword
            null,
    // owner password => required to __modify__ document/permissions        
            System.Text.Encoding.UTF8.GetBytes("ownerPassword"),
    /*
     * bitwise or => see iText API for permission parameter:
     * http://api.itextpdf.com/itext/com/itextpdf/text/pdf/PdfWriter.html
     */
            PdfWriter.ALLOW_PRINTING
                | PdfWriter.ALLOW_COPY
            , 
    // encryption level also in documentation referenced above        
            PdfWriter.ENCRYPTION_AES_128
          );
          document.Open();
          document.Add(new Paragraph("hello world"));
        }
      }
      public bool IsReusable { get { return false; } }
    }
