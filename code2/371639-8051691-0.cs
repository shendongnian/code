    private void Button1_Click(System.Object sender, 
    		System.EventArgs e)
    	{
    
    		// Allow the user to choose the page range he or she would
    		// like to print.
    		PrintDialog1.AllowSomePages = true;
    
    		// Show the help button.
    		PrintDialog1.ShowHelp = true;
    
    		// Set the Document property to the PrintDocument for 
    		// which the PrintPage Event has been handled. To display the
    		// dialog, either this property or the PrinterSettings property 
    		// must be set 
    		PrintDialog1.Document = docToPrint;
    
    		DialogResult result = PrintDialog1.ShowDialog();
    
    		// If the result is OK then print the document.
    		if (result==DialogResult.OK)
    		{
    			docToPrint.Print();
    		}
    
    	}
