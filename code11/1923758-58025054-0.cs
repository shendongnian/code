    public class MyPdfPageEventHandler: PdfPageEventHelper
    {
        const float horizontalPosition = 0.5f;  // %50 of the page width, starting from the left
        const float verticalPosition = 0.1f;    // %10 of the page height starting from the bottom
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            var footerText = new Phrase(writer.CurrentPageNumber.ToString());
            float posX = writer.PageSize.Width * horizontalPosition;
            float posY = writer.PageSize.Height * verticalPosition;
            float rotation = 0;
            ColumnText.ShowTextAligned(writer.DirectContent, Element.PHRASE, footerText, posX, posY, rotation);
        }
    }
