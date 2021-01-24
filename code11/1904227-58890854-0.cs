    protected void convertToPdfButton_Click(object sender, EventArgs e)
    {
        // Create the PDF document where to add the HTML documents
        Document pdfDocument = new Document();
    
        // Create a PDF page where to add the first HTML
        PdfPage firstPdfPage = pdfDocument.AddPage();
    
        try
        {
            // Create the first HTML to PDF element
            HtmlToPdfElement firstHtml = new HtmlToPdfElement(0, 0, firstUrlTextBox.Text);
    
            // Optionally set a delay before conversion to allow asynchonous scripts to finish
            firstHtml.ConversionDelay = 2;
    
            // Add the first HTML to PDF document
            AddElementResult firstAddResult = firstPdfPage.AddElement(firstHtml);
    
            PdfPage secondPdfPage = null;
            PointF secondHtmlLocation = Point.Empty;
    
            if (startNewPageCheckBox.Checked)
            {
                // Create a PDF page where to add the second HTML
                secondPdfPage = pdfDocument.AddPage();
                secondHtmlLocation = PointF.Empty;
            }
            else
            {
                // Add the second HTML on the PDF page where the first HTML ended
                secondPdfPage = firstAddResult.EndPdfPage;
                secondHtmlLocation = new PointF(firstAddResult.EndPageBounds.Left, firstAddResult.EndPageBounds.Bottom);
            }
    
            // Create the second HTML to PDF element
            HtmlToPdfElement secondHtml = new HtmlToPdfElement(secondHtmlLocation.X, secondHtmlLocation.Y, secondUrlTextBox.Text);
    
            // Optionally set a delay before conversion to allow asynchonous scripts to finish
            secondHtml.ConversionDelay = 2;
    
            // Add the second HTML to PDF document
            secondPdfPage.AddElement(secondHtml);
    
            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();
    
            // Send the PDF as response to browser
    
            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");
    
            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Merge_Multipe_HTML.pdf; size={0}", outPdfBuffer.Length.ToString()));
    
            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);
    
            // End the HTTP response and stop the current page processing
            Response.End();
        }
        finally
        {
            // Close the PDF document
            pdfDocument.Close();
        }
    }
