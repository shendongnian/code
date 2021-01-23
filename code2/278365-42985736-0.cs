    public void GeneratePdf(string htmlPdf)
    {
	    var pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
	    var htmlparser = new HTMLWorker(pdfDoc);
	    using (var memoryStream = new MemoryStream())
	    {
		    var writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
		    pdfDoc.Open();
		    htmlparser.Parse(new StringReader(htmlPdf));
		    pdfDoc.Close();
		    byte[] bytes = memoryStream.ToArray();
		    File.WriteAllBytes(@"C:\file.pdf", bytes);
		    memoryStream.Close();
	    }
    }
