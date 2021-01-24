     public class itsEventsHandler : PdfPageEventHelper
     {
       int pageCount;
       protected PdfPTable tblAccInfo = new PdfPTable(3);
       public itsEventsHandler()
       {
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
         this.BuildBorderCell(tblAccInfo, "A/C No.", boldFont);
         this.BuildBorderCell(tblAccInfo, "External Doc No.", boldFont);
         this.BuildBorderCell(tblAccInfo, "PAGE", boldFont);
         this.BuildBorderCell(tblAccInfo, accountNo, titleFont);
         this.BuildBorderCell(tblAccInfo, docNo, titleFont);
         this.BuildBorderCell(tblAccInfo, pageCount.ToString(), titleFont);
         //Writing the table
         tblAccInfo.WriteSelectedRows(0, -1, document.LeftMargin + 53f, 
         document.PageSize.Height - 250f, writer.DirectContent);
         //Droping the table
         tblAccInfo = null;
      }     
    }
