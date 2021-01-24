	static void Main(string[] args)
	{
		using (WordprocessingDocument document = 
			WordprocessingDocument.Open("Document.docx", true))
		{
			MainDocumentPart mainDocumentPart = document.MainDocumentPart;
			// Delete the existing footer parts
			mainDocumentPart.DeleteParts(mainDocumentPart.FooterParts);
			// Create a new footer part
			FooterPart footerPart = mainDocumentPart.AddNewPart<FooterPart>();
			// Get Id of footer part
			string footerPartId = mainDocumentPart.GetIdOfPart(footerPart);
			GenerateFooterPartContent(footerPart);
			// Get SectionProperties and Replace FooterReference with new Id
			IEnumerable<SectionProperties> sections = 
				mainDocumentPart.Document.Body.Elements<SectionProperties>();
			foreach (var section in sections)
			{
				// Delete existing references to headers and footers
				section.RemoveAllChildren<FooterReference>();
				// Create the new header and footer reference node
				section.PrependChild<FooterReference>(
					new FooterReference() { Id = footerPartId });
			}
		}
	}
	static void GenerateFooterPartContent(FooterPart part)
	{
		Footer footer1 = new Footer();
		Paragraph paragraph1 = new Paragraph();
		ParagraphProperties paragraphProperties1 = new ParagraphProperties();
		ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId() { Val = "Footer" };
		paragraphProperties1.Append(paragraphStyleId1);
		Run run1 = new Run();
		Text text1 = new Text();
		text1.Text = "Footer";
		run1.Append(text1);
		paragraph1.Append(paragraphProperties1);
		paragraph1.Append(run1);
		footer1.Append(paragraph1);
		part.Footer = footer1;
	}
