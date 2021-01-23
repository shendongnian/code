    PdfReader reader = new PdfReader(somePDF);
	PdfDictionary pageDict = reader.GetPageN(1);
	PdfArray annotArray = pageDict.GetAsArray(PdfName.ANNOTS);
	for (int i = 0; i < annotArray.Size; ++i)
	{
		PdfDictionary curAnnot = annotArray.GetAsDict(i);
		PdfString name = curAnnot.GetAsString(PdfName.T);
		PdfString contents = curAnnot.GetAsString(PdfName.CONTENTS);
		if (!string.IsNullOrWhiteSpace(name?.ToString()))
		{ Console.WriteLine(name); }
		if (!string.IsNullOrWhiteSpace(contents?.ToString()))
		{ Console.WriteLine(contents); }
	}
