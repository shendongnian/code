        PdfDocument pdfDoc = new PdfDocument(new PdfWriter(DEST));
        Document doc = new Document(pdfDoc);
        Paragraph p = new Paragraph();
        string original = "Some text";
        string first = original.Substring(0, 1);
        p.Add(new Text(first)
                .SetFontColor(ColorConstants.BLUE));
        p.Add(original.Substring(1, original.Length - 1));
        doc.Add(p);
        doc.Close();
