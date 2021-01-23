    try {
    
    	Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
    	appWord.Visible = false;
    	Microsoft.Office.Interop.Word.Document doc = null;
    	wordDocument = appWord.Documents.Open((INP), ReadOnly: true);
    	  
    	wordDocument.ExportAsFixedFormat(OUTP, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
    	   
    	// doc.Close(false); // Close the Word Document.
    	appWord.Quit(false); // Close Word Application.
    } catch (Exception ex) {
    	Console.WriteLine(ex.Message + "     " + ex.InnerException);
    }
