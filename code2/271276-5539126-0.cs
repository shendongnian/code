    <%@ WebHandler Language='C#' Class='addBarcodeWithStamper' %>
    using System;
    using System.IO;
    using System.Web;
    using iTextSharp.text;  
    using iTextSharp.text.pdf; 
    
    public class addBarcodeWithStamper : IHttpHandler {
      public void ProcessRequest (HttpContext context) {
        HttpResponse Response = context.Response;
        Response.ContentType = "application/pdf";
        PdfReader reader = new PdfReader(context.Server.MapPath(PATH_TO_PDF));
    /*
     * save __one__ instance of barcode image;
     * see MakeBarcode() method below
     */
        iTextSharp.text.Image barcode = null;
        float barcodeWidth = 0;
        float barcodeHeight = 0;
        using (PdfStamper stamper = new PdfStamper(reader, Response.OutputStream)) 
        {
          int n = reader.NumberOfPages;
          for (int i = 1; i <= n; i++) {
            PdfContentByte cb = stamper.GetOverContent(i);
    /*
     *  re-use image bytes so they are added only __once__
     */
            if (barcode == null) {
              barcode = MakeBarcode(cb);
              barcodeWidth= barcode.Width;
              barcodeHeight= barcode.Height;
            }
    /*
     * calculate in case individual page sizes are different
     */
            Rectangle rect = stamper.Reader.GetPageSize(i);
            float x = (rect.Width - barcodeWidth) / 2;
            float y = rect.Top - barcodeHeight - 10;
            barcode.SetAbsolutePosition(x, y);
            cb.AddImage(barcode);
          }    
        }
    
      }
      public bool IsReusable {
        get { return false; }
      }
    // ----------------------------------------------------------------------------  
      public iTextSharp.text.Image MakeBarcode(PdfContentByte cb) {
        Barcode128 barcode128 = new Barcode128();
        string text2 = "650-M5-013";
        barcode128.Code = text2;
        barcode128.ChecksumText = true;        
        return barcode128.CreateImageWithBarcode(cb, null, null);  
      }
    }
