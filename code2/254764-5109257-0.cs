	//Create a new document
	iTextSharp.text.Document Doc = new iTextSharp.text.Document(PageSize.LETTER, 20, 20, 20, 20);
	//Store the document on the desktop
	string PDFOutput = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Output.pdf");
	PdfWriter writer = PdfWriter.GetInstance(Doc, new FileStream(PDFOutput, FileMode.Create, FileAccess.Write, FileShare.Read));
	//Open the PDF for writing
	Doc.Open();
	string Folder = "C:\\Images";
	foreach (string F in System.IO.Directory.GetFiles(Folder, "*.jpg")) {
		//Insert a page
		Doc.NewPage();
		//Add image
		Doc.Add(new iTextSharp.text.Jpeg(new Uri(new FileInfo(F).FullName)));
	}
	//Close the PDF
	Doc.Close();
