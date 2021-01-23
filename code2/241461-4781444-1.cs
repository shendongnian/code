    Document pdf = new Document(PageSize.A4);
    PdfWriter.GetInstance(pdf, new FileStream("file.pdf", System.IO.FileMode.Create));
    pdf.Open();
    pdf.Add(new Paragraph("This is a pdf document!"));
    pdf.Close();
