	foreach (var html in htmlList)
	{
		MemoryStream baos = new MemoryStream();
		PdfDocument temp = new PdfDocument(new PdfWriter(baos));
		HtmlConverter.ConvertToPdf(html, temp, properties);              
		ReaderProperties rp = new ReaderProperties();
		baos = new MemoryStream(baos.ToArray());
		temp = new PdfDocument(new PdfReader(baos, rp));
		pdfMerger.Merge(temp, 1, temp.GetNumberOfPages());
		temp.Close();
	}
	pdfMerger.Close();
