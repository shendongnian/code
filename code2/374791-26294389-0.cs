    var applicationWord = new Microsoft.Office.Interop.Word.Application();
    adoc = applicationWord.Documents.Open(ref ofileName);
    foreach (Section oSection in adoc.Sections)
    {
    	foreach (HeaderFooter OHeader in oSection.Headers)
    	{
    		foreach(Microsoft.Office.Interop.Word.Shape Headershape in OHeader.Shapes)
    		{
    			Headershape.Delete();
    			OHeader.Shapes.AddPicture(m_sLogoPath);
    		}
    	}
    }
