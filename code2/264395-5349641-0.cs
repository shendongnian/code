    <%@ WebHandler Language='C#' Class='LandscapeToPortrait' %>
    using System;
    using System.IO;
    using System.Web;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    public class LandscapeToPortrait : IHttpHandler {
      public void ProcessRequest (HttpContext context) {
        HttpResponse Response = context.Response;
        Response.ContentType = "application/pdf";
        PdfReader[] readers = {
          new PdfReader(CreateReaderBytes(false)),
          new PdfReader(CreateReaderBytes(true))
        };
        
        using (Document doc = new Document()) {
          using (PdfCopy copy = new PdfCopy(doc, Response.OutputStream)) {
            doc.Open();
            foreach (PdfReader reader in readers) {
              int n = reader.NumberOfPages;
              for (int page = 0; page < n;) {
                ++page;
                float width = reader.GetPageSize(page).Width;
                float height = reader.GetPageSize(page).Height;
                if (width > height) {
                  PdfDictionary pageDict = reader.GetPageN(page);
                  pageDict.Put(PdfName.ROTATE, new PdfNumber(90));
                }
                copy.AddPage(copy.GetImportedPage(reader, page));
              }
            }        
          }
        }
      }
      public bool IsReusable {
        get { return false; }
      }
      public byte[] CreateReaderBytes(bool isLandscape) {
        using (MemoryStream ms = new MemoryStream()) {
          Rectangle r = isLandscape
            ? new Rectangle(792, 612)
            : PageSize.LETTER
          ;
          using (Document doc = new Document(r)) {
            PdfWriter.GetInstance(doc, ms);
            doc.Open();
            for (int i = 0; i < 5; ++i) {
              doc.Add(new Phrase("hello world"));
              doc.NewPage();
            }
          }
          return ms.ToArray();
        }
      }
    }
