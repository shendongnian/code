    private void btnExtractImages_Click(object sender, EventArgs e)
    {
        if (pdfFileTextBox.Text.Trim().Equals(String.Empty))
        {
            MessageBox.Show("Please choose a source PDF file", "Choose PDF file", MessageBoxButtons.OK);
            return;
        }
    
        // the source pdf file
        string pdfFileName = pdfFileTextBox.Text.Trim();
    
        // start page number
        int startPageNumber = int.Parse(textBoxStartPage.Text.Trim());
        // end page number
        // when it is 0 the extraction will continue up to the end of document
        int endPageNumber = 0;
        if (textBoxEndPage.Text.Trim() != String.Empty)
            endPageNumber = int.Parse(textBoxEndPage.Text.Trim());
    
        // create the PDF images extractor object
        PdfImagesExtractor pdfImagesExtractor = new PdfImagesExtractor();
    
        pdfImagesExtractor.LicenseKey = "31FAUEJHUEBQRl5AUENBXkFCXklJSUlQQA==";
    
        // the demo output directory
        string outputDirectory = Path.Combine(Application.StartupPath, @"DemoFiles\Output");
    
        Cursor = Cursors.WaitCursor;
                
        // set the handler to be called when an image was extracted
        pdfImagesExtractor.ImageExtractedEvent += pdfImagesExtractor_ImageExtractedEvent;
                
        try
        {
            // start images counting
            imageIndex = 0;
    
            // call the images extractor to raise the ImageExtractedEvent event when an images is extracted from a PDF page
            // the pdfImagesExtractor_ImageExtractedEvent handler below will be executed for each extracted image
            pdfImagesExtractor.ExtractImagesInEvent(pdfFileName, startPageNumber, endPageNumber);
    
            // Alternatively you can use the ExtractImages() and ExtractImagesToFile() methods
            // to extracted the images from a PDF document in memory or to image files in a directory
    
            // uncomment the line below to extract the images to an array of ExtractedImage objects
            //ExtractedImage[] pdfPageImages = pdfImagesExtractor.ExtractImages(pdfFileName, startPageNumber, endPageNumber);
    
            // uncomment the lines below to extract the images to image files in a directory
            //string outputDirectory = System.IO.Path.Combine(Application.StartupPath, @"DemoFiles\Output");
            //pdfImagesExtractor.ExtractImagesToFile(pdfFileName, startPageNumber, endPageNumber, outputDirectory, "pdfimage");
        }
        catch (Exception ex)
        {
            // The extraction failed
            MessageBox.Show(String.Format("An error occurred. {0}", ex.Message), "Error");
            return;
        }
        finally
        {
            // uninstall the event handler
            pdfImagesExtractor.ImageExtractedEvent -= pdfImagesExtractor_ImageExtractedEvent;
    
            Cursor = Cursors.Arrow;
        }
    
        try
        {
            System.Diagnostics.Process.Start(outputDirectory);
        }
        catch (Exception ex)
        {
            MessageBox.Show(string.Format("Cannot open output folder. {0}", ex.Message));
            return;
        }
    }
    
    /// <summary>
    /// The ImageExtractedEvent event handler called after an image was extracted from a PDF page.
    /// The event is raised when the ExtractImagesInEvent() method is used
    /// </summary>
    /// <param name="args">The handler argument containing the extracted image and the PDF page number</param>
    void pdfImagesExtractor_ImageExtractedEvent(ImageExtractedEventArgs args)
    {
        // get the image object and page number from even handler argument
        Image pdfPageImageObj = args.ExtractedImage.ImageObject;
        int pageNumber = args.ExtractedImage.PageNumber;
    
        // save the extracted image to a PNG file
        string outputPageImage = Path.Combine(Application.StartupPath, @"DemoFiles\Output", 
            "pdfimage_" + pageNumber.ToString() + "_" + imageIndex++ + ".png");
        pdfPageImageObj.Save(outputPageImage, ImageFormat.Png);
    
        args.ExtractedImage.Dispose();
    }
