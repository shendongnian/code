    <%@ WebHandler Language="C#" Class="appendExisting" %>
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Web;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    public class appendExisting : IHttpHandler {
      public void ProcessRequest (HttpContext context) {
        HttpResponse Response = context.Response;
        HttpServerUtility Server = context.Server;
        Response.ContentType = "application/pdf";
        string[] bufList = {
          Server.MapPath("~/app_data/01.pdf"),
          Server.MapPath("~/app_data/02.pdf"),
          Server.MapPath("~/app_data/01.jpg"),
          Server.MapPath("~/app_data/02.png")
        };
        using (Document document = new Document()) {
          PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);
          document.Open();
    
    // simulate the existing content you were asking about
          document.Add(new Paragraph("Paragraph"));
    
          PdfContentByte cb = writer.DirectContent;
          foreach (var buf in bufList) {
            bool isPdf = Regex.IsMatch(
              Path.GetExtension(buf), @"\.pdf$", RegexOptions.IgnoreCase
            );
            if (isPdf) {
              PdfReader reader = new PdfReader(buf);
              int pages = reader.NumberOfPages;
              for (int i = 0; i < pages; ) {
                document.NewPage();
                PdfImportedPage page = writer.GetImportedPage(reader, ++i);
                cb.AddTemplate(page, 1, 0, 0, 1, 0, 0);
              }
            }
            else {
              document.NewPage();
              iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(buf);
              img.ScaleToFit(612f, 792f);
              img.Alignment = iTextSharp.text.Image.ALIGN_CENTER 
                  | iTextSharp.text.Image.ALIGN_MIDDLE
              ;
              document.Add(img);        
            }
          }
        }
      }
      public bool IsReusable {
        get { return false; }
      }
    }
