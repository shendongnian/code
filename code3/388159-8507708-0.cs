    Response.ContentType = "application/pdf";
    Response.AppendHeader(
      "Content-Disposition",
      "attachment; filename=test.pdf"
    );
    using (Document document = new Document()) {
      PdfWriter.GetInstance(document, Response.OutputStream);
      document.Open();
      document.Add(new Paragraph("This is a paragraph"));
    }
