	static void RemoveLinks(PdfReader reader, int sourcePage, Stream output)
	{
		// PdfStamper to alter the file
		PdfStamper stamper = new PdfStamper(reader, output);
		PdfDictionary sourcePageDict = reader.GetPageNRelease(sourcePage);
		PdfArray annotations = sourcePageDict.GetAsArray(PdfName.ANNOTS);
		// Annotations to keep
		PdfArray newannots = new PdfArray();
		if (annotations != null && annotations.Size > 0)
		{
			foreach (PdfObject item in annotations)
			{
				PdfObject annotationObject = PdfReader.GetPdfObject(item);
				if (!annotationObject.IsDictionary())
					continue;
				PdfDictionary annotation = (PdfDictionary)annotationObject;
				if (!PdfName.LINK.Equals(annotation.GetAsName(PdfName.SUBTYPE)))
					// Keep annotation when it's not a link annotation
					newannots.Add(item);
			}
			// Replace annots array for this page
			sourcePageDict.Put(PdfName.ANNOTS, newannots);
		}
		stamper.Close();
	}
