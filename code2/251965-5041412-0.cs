    <%@ WebHandler Language='C#' Class='tableColumnWidths' %>
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web;
    using iTextSharp.text;
    using iTextSharp.text.html.simpleparser;
    using iTextSharp.text.pdf;
    
    public class tableColumnWidths : IHttpHandler {
      public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "application/pdf";
        string html = @"
    <html><head></head><body> 
    <p>A paragraph</p>   
    <table border='1'>
    <tr><td>row1-column1</td><td>row1-column2</td><td>row1-column3</td></tr>
    <tr><td>row2-column1</td><td>row2-column2</td><td>row2-column3</td></tr>
    </table>
    </body></html>
        ";
    /*
     * need the Rectangle for later when we set the column widths
     */
        Rectangle rect = PageSize.LETTER;
        Document document = new Document(rect);
        PdfWriter.GetInstance(document, context.Response.OutputStream);
        document.Open();
    /* 
     * iterate over iText elements
     */
        List<IElement> ie = HTMLWorker.ParseToList(
          new StringReader(html), null
        );
    /*
     * page width
     */
        float pageWidth = rect.Width;
    /*
     * look for PdfPTable(s)
     */
        foreach (IElement element in ie) {
          PdfPTable table = element as PdfPTable;
    /*
     * set the column widths
     */
          if (table != null) {
            table.SetWidthPercentage(
              new float[] {
                (float).25 * pageWidth, 
                (float).50 * pageWidth, 
                (float).25 * pageWidth
              },
              rect
            );
          }
          document.Add(element); 
        } 
        document.Close();  
      }
      public bool IsReusable {
        get { return false; }
      }
    }
 
