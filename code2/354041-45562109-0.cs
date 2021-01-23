	static void Main(string[] args)
	{
		string html = File.ReadAllText(@"C:\Temp\Test.html");
		PdfDocument pdf = PdfGenerator.GeneratePdf(html, PageSize.A4, 20, null, OnStylesheetLoad, OnImageLoadPdfSharp);
		pdf.Save(@"C:\Temp\Test.pdf");
	}
	public static void OnImageLoadPdfSharp(object sender, HtmlImageLoadEventArgs e)
	{
		var imgObj = Image.FromFile(@"C:\Temp\Test.png");
		e.Callback(XImage.FromGdiPlusImage(imgObj));	
	}
	public static void OnStylesheetLoad(object sender, HtmlStylesheetLoadEventArgs e)
	{
		e.SetStyleSheet = @"h1, h2, h3 { color: navy; font-weight:normal; }";
	}
