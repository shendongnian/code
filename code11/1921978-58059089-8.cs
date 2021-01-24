     protected FrameworkElement firstPage;
     public void PaginateManifestLabel(object sender, PaginateEventArgs e)
        {
            // Clear the cache of preview pages
            printPreviewPages.Clear();
            // Clear the print canvas of preview pages
            PrintCanvas.Children.Clear();
            // This variable keeps track of the last RichTextBlockOverflow element that was added to a page which will be printed
            ListView lastRTBOOnPage = null;
            // Get the PrintTaskOptions
            PrintTaskOptions printingOptions = ((PrintTaskOptions)e.PrintTaskOptions);
            // Get the page description to deterimine how big the page is
            PrintPageDescription pageDescription = printingOptions.GetPageDescription(0);
            // We know there is at least one page to be printed. passing null as the first parameter to
            // AddOnePrintPreviewPage tells the function to add the first page.
            //lastRTBOOnPage = AddOnePrintPreviewPage(null, pageDescription);
            // We know there are more pages to be added as long as the last RichTextBoxOverflow added to a print preview
            // page has extra content
            int i = 0;
            while (i < _totalPages)
            {
                _manifestPDFDataModelforPriniPagination.ItemsPDFList = tempList.ItemsPDFList.Skip(i * 11).Take(11).ToList();
              
                lastRTBOOnPage = AddOnePrintPreviewPage(lastRTBOOnPage, pageDescription);
                i++;
            }
           
            PrintDocument printDoc = (PrintDocument)sender;
            
            // Report the number of preview pages created
            printDoc.SetPreviewPageCount(printPreviewPages.Count, PreviewPageCountType.Intermediate);
        }
