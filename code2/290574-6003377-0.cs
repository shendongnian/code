    var pdfVision = new SautinSoft.PdfVision();
    var pdfBytes = pdfVision.ConvertHtmlFileToPDFStream("http://localhost/default.aspx");
    
    //show PDF            
    Response.Buffer = true;
    Response.Clear();
    Response.ContentType = "application/PDF";
    Response.AddHeader("Content-Disposition:", "attachment; filename=Result.pdf");
    Response.BinaryWrite(pdfBytes);
    Response.Flush();
    Response.End();
