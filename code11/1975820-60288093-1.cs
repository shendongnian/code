MemoryStream ms = new MemoryStream();
using (PdfWriter writer = new PdfWriter(ms))
using (PdfDocument pdfDocument = new PdfDocument(writer))
using (Document document = new Document(pdfDocument))
{
    /*
     * Depending on iTextSharp version, you might instead use:
     *     writer.SetCloseStream(false);
     */
    writer.CloseStream = false; 
    document.Add(new Paragraph("Hello World"));
}
ms.Position = 0;
string pdfName = $"IP-Report-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.pdf";
return File(ms, "application/pdf", pdfName);
