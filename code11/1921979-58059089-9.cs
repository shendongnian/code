    private ListView AddOnePrintPreviewPage(ListView lastRTBOAdded, PrintPageDescription printPageDescription)
        {
            // XAML element that is used to represent to "printing page"
            FrameworkElement page;
            // The link container for text overflowing in this page
            ListView textLink;
            // Check if this is the first page ( no previous RichTextBlockOverflow)
            if (lastRTBOAdded == null)
            {
                // If this is the first page add the specific scenario content
                page = firstPage;
            }
            else
            {
                // Flow content (text) from previous pages
                page = new GenericManifestPDF(_manifestPDFDataModelforPriniPagination);
            }
            // Set "paper" width
            page.Width = printPageDescription.PageSize.Width;
            page.Height = printPageDescription.PageSize.Height;
            // Find the last text container and see if the content is overflowing
            textLink = (ListView)page.FindName("PDFItemsList");
            // Add the page to the page preview collection
            printPreviewPages.Add(page);
            return textLink;
        }
