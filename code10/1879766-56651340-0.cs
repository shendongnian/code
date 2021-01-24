    public class OnStartPageTestHandler : PdfPageEventHelper
    {
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            Console.WriteLine("OnStartPage - PdfWriter {0}, Document {1}", writer.CurrentPageNumber, document.PageNumber);
        }
    }
