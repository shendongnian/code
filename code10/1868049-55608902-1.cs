     public class itsEventsHandler : PdfPageEventHelper
     {
       int pageCount;
       protected PdfPTable tblAccInfo = new PdfPTable(3);
       public itsEventsHandler()
       {
       }
       public void BuildBorderCell(PdfPTable pdfTable, string strText, 
          iTextSharp.text.Font font)
       {
            PdfPCell cell = new PdfPCell(new Phrase(strText, font));
            cell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
            cell.PaddingTop = 5f;
            pdfTable.AddCell(cell);
       }
       public override void OnEndPage(PdfWriter writer, Document document)
       {
         pageCount = writer.PageNumber;
    
         //Creating the table
         PdfPTable tblAccInfo = new PdfPTable(3);
         tblAccInfo.TotalWidth = 450f;
         float[] accInfoWidths = new float[] { 50f, 50f, 50f};
         tblAccInfo.SetWidths(accInfoWidths);
         //Building table cell
         BuildBorderCell(tblAccInfo, "A/C No.", boldFont);
         BuildBorderCell(tblAccInfo, "External Doc No.", boldFont);
         BuildBorderCell(tblAccInfo, "PAGE", boldFont);
         BuildBorderCell(tblAccInfo, accountNo, titleFont);
         BuildBorderCell(tblAccInfo, docNo, titleFont);
         BuildBorderCell(tblAccInfo, pageCount.ToString(), titleFont);
         //Writing the table
         tblAccInfo.WriteSelectedRows(0, -1, document.LeftMargin + 53f, 
         document.PageSize.Height - 250f, writer.DirectContent);
         //Droping the table
         tblAccInfo = null;
      }     
    }
