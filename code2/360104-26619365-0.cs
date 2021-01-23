	void Setup_Printing()
	{
	  myPrintDocument.BeginPrint += On_BeginPrint;
	  myPrintDocument.PrintPage += On_PrintPage;
	}
	// Page Index variable
	int indexCuurentPage = 0;
	void On_BeginPrint(object sender, PrintEventArgs e)
	{
	  indexCuurentPage = 0;
	  ((PrintDocument)sender).PrinterSettings.PrintRange = PrintRange.SomePages;
	  ((PrintDocument)sender).PrinterSettings.FromPage = 3;
	  ((PrintDocument)sender).PrinterSettings.ToPage = 5;
	}
	void On_PrintPage(object sender, PrintPageEventArgs ppea)
	{
	  // Set up a loop to process pages.
	  bool bProcessingPages = true;
	  while (bProcessingPages)
	  {
		indexCurrentPage++;
		// Set isPageInRange flag to true if this indexCurrentPage is in the selected range of pages
		bool isPageInRange = (theCurrentPage >= ppea.PageSettings.PrinterSettings.FromPage);
		isPageInRange = isPageInRange && (theCurrentPage =< ppea.PageSettings.PrinterSettings.ToPage);
		if (isPageInRange)
		{
		  // Process your data and print this page then exit the loop.  
		  try
		  {
			//// TO DO - Process Data ////
			//// TO DO - Draw Data to ppea.Graphics ////
			// Note:  Do not set the ppea.HasMorePages to true.  Let the Printer Controller do it.
		  }
		  catch
		  {
			// Abort printing more pages if there was an error.
			ppea.HasMorePages = false;
		  }
		  // Set the loop exit flag.  We could use "return;" instead if we do not want to do more.
		  bProcessingPages = false;
		}
		else
		{
		  // Process your data and Do Not Draw on the ppea.Graphics.
		  try
		  {
			//// TO DO - Process Data ////
		  }
		  catch
		  {
			// Abort printing more pages if there was an error.
			ppea.HasMorePages = false;
			// Set the loop exit flag.  We could use "return;" instead if we do not want to do more.
			bProcessingPages = false;
		  }
		  // Stay in the processing loop until you either need to actually Print a Page
          // or until you run out of data and pages to print.
		}
		// check to see if we ran out of pages to print
		if (indexCurrentPage >= ppea.PageSettings.PrinterSettings.ToPage)
		{
		  // Done.  We do not need to set the HasMorePages = false
		  bProcessingPages = false;
		}
	  } // end while processing pages
      // The print controller will decide to raise the next PrintPage event if it needs to.
      // If You set the ppea.HasMorePages = false, then it will stop any more page events. 
      // If You set the ppea.HasMorePages = true, 
      //    then I'm not sure what the print controller will do if it ran out of pages!
	}
