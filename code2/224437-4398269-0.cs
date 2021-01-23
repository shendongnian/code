    // Create and configure PdfConverter
    //
    var pdfConverter = new PdfConverter();
    ...
    
    // Get PDF as bytes
    //
    byte[] downloadBytes = pdfConverter.GetPdfBytesFromUrl(url);
    Response.Clear();
    Response.ContentType = MediaTypeNames.Application.Pdf;
    Response.AddHeader("Content-Disposition", "inline;filename=SharePointPage.pdf");
    Response.BinaryWrite(bytes);
    Response.Flush();
    Response.End();
