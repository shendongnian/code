    private void PreparePrintContent()
    {
        PrintingRoot.Children.Clear();
        // Create and populate print page.
        var printPage = Activator.CreateInstance(this.printPageType) as Page;
        printPage.DataContext = this.DataContext;
        var printPageRtb = printPage.Content as RichTextBlock;
        while (printPageRtb.Blocks.Count > 0)
        {
            PrintPage firstPage = new PrintPage();
            firstPage.AddContent(new Paragraph());
            var paragraph = printPageRtb.Blocks.First() as Paragraph;
            printPageRtb.Blocks.Remove(paragraph);
            
            firstPage.AddContent(paragraph);
            NeedToPrintPages.Add(firstPage);
            PrintingRoot.Children.Add(firstPage);
        };
    }
    private RichTextBlockOverflow AddOnePrintPreviewPage(RichTextBlockOverflow lastRTBOAdded, PrintPageDescription printPageDescription,int index)
    {
        ......
        if (lastRTBOAdded == null)
        {
            // If this is the first page add the specific scenario content
            page = NeedToPrintPages[index];
        }
        ......
    }
    private void PrintDocument_Paginate(object sender, PaginateEventArgs e)
    {
        // Clear the cache of preview pages 
        printPreviewPages.Clear();
        this.pageNumber = 0;
        // Clear the printing root of preview pages
        PrintingRoot.Children.Clear();
        for (int i = 0; i < NeedToPrintPages.Count; i++) {
            // This variable keeps track of the last RichTextBlockOverflow element that was added to a page which will be printed
            RichTextBlockOverflow lastRTBOOnPage;
            // Get the PrintTaskOptions
            PrintTaskOptions printingOptions = ((PrintTaskOptions)e.PrintTaskOptions);
            // Get the page description to deterimine how big the page is
            PrintPageDescription pageDescription = printingOptions.GetPageDescription(0);
            // We know there is at least one page to be printed. passing null as the first parameter to
            // AddOnePrintPreviewPage tells the function to add the first page.
            lastRTBOOnPage = AddOnePrintPreviewPage(null, pageDescription,i);
            // We know there are more pages to be added as long as the last RichTextBoxOverflow added to a print preview
            // page has extra content
            while (lastRTBOOnPage.HasOverflowContent && lastRTBOOnPage.Visibility == Windows.UI.Xaml.Visibility.Visible)
            {
                lastRTBOOnPage = AddOnePrintPreviewPage(lastRTBOOnPage, pageDescription,i);
            }
        }
        PrintDocument printDoc = (PrintDocument)sender;
        // Report the number of preview pages created
        printDoc.SetPreviewPageCount(printPreviewPages.Count, PreviewPageCountType.Intermediate);
    }
