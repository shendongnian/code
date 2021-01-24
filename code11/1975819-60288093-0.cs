MemoryStream ms = new MemoryStream();
using (PdfWriter writer = new PdfWriter(ms))
using (PdfDocument pdfDocument = new PdfDocument(writer))
using (Document document = new Document(pdfDocument))
{
    writer.CloseStream = false;
    document.Add(new Paragraph("Hello World"));
}
ms.Position = 0;
string pdfName = $"IP-Report-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.pdf";
return File(ms, "application/pdf", pdfName);
