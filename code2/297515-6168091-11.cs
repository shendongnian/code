    acPDFCreatorLib.Initialize();
    acPDFCreatorLib.SetLicenseKey("Amyuni Tech.", "07EFCDA00...BC4FB9CFD");
    Amyuni.PDFCreator.IacDocument document = pdfCreator1.Document;
    
    // Open a PDF document from file
    System.IO.FileStream file1 = new System.IO.FileStream("test_input.pdf", FileMode.Open, FileAccess.Read, FileShare.Read);
     
    IacDocument document = new IacDocument(null);
     
    if (document.Open(file1, ""))
    {
    	//Set AutoPrint
    	document.Attribute("AutoPrint").Value = true;
    
    	//Save the document
    	System.IO.FileStream file2 = new System.IO.FileStream("test_output.pdf", System.IO.FileMode.Create, System.IO.FileAccess.Write);
    	document.Save(file2, Amyuni.PDFCreator.IacFileSaveOption.acFileSaveView);
    }
    
    // Disposing the document before closing the stream clears out any data structures used by the Document object
    document.Dispose();
    
    file1.Close();
    
    // terminate library to free resources
    acPDFCreatorLib.Terminate();
