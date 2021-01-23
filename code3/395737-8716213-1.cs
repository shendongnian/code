    <%@ WebHandler Language="C#" Class="scaleDocToImageSize" %>
    using System;
    using System.Web;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    public class scaleDocToImageSize : IHttpHandler {
      public void ProcessRequest (HttpContext context) {
        HttpServerUtility Server = context.Server;
        HttpResponse Response = context.Response;
        Response.ContentType = "application/pdf";
        string[] imagePaths = {"./Image15.png", "./Image19.png"};
        using (Document document = new Document()) {
          PdfWriter.GetInstance(document, Response.OutputStream);
          document.Open();
          document.Add(new Paragraph("Page 1"));
          foreach (string path in imagePaths) {
            string imagePath = Server.MapPath(path);
            Image img = Image.GetInstance(imagePath);
    
            var width = img.ScaledWidth 
              + document.RightMargin
              + document.LeftMargin
            ;
            var height = img.ScaledHeight
              + document.TopMargin
              + document.BottomMargin
            ;
            Rectangle r = width > PageSize.A4.Width || height > PageSize.A4.Height
              ? new Rectangle(width, height)
              : PageSize.A4
            ;
    /*
     * you __MUST__ call SetPageSize() __BEFORE__ calling NewPage()
     * AND __BEFORE__ adding the image to the document
     */
            document.SetPageSize(r);
            document.NewPage();
            document.Add(img);
          }
        }
      }
      public bool IsReusable { get { return false; } }
    }
