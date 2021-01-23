    protected void convertToPdfButton_Click(object sender, EventArgs e)
    {
        // Create a HTML to PDF converter object with default settings
        HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();
    
        // Set license key received after purchase to use the converter in licensed mode
        // Leave it not set to use the converter in demo mode
        htmlToPdfConverter.LicenseKey = "fvDh8eDx4fHg4P/h8eLg/+Dj/+jo6Og=";
    
        Document pdfDocument = null;
        try
        {
            // Convert a HTML page to a PDF document object
            pdfDocument = htmlToPdfConverter.ConvertUrlToPdfDocumentObject(urlTextBox.Text);
    
            string javaScript = null;
            if (alertMessageRadioButton.Checked)
            {
                // JavaScript to display an alert mesage 
                javaScript = String.Format("app.alert(\"{0}\")", alertMessageTextBox.Text);
            }
            else if (printDialogRadioButton.Checked)
            {
                // JavaScript to open the print dialog
                javaScript = "print()";
            }
            else if (zoomLevelRadioButton.Checked)
            {
                // JavaScript to set an initial zoom level 
                javaScript = String.Format("zoom={0}", int.Parse(zoomLevelTextBox.Text));
            }
    
            // Set the JavaScript action
            pdfDocument.OpenAction.Action = new PdfActionJavaScript(javaScript);
    
            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();
    
            // Send the PDF as response to browser
    
            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");
    
            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Execute_Acrobat_JavaScript.pdf; size={0}", outPdfBuffer.Length.ToString()));
    
            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);
    
            // End the HTTP response and stop the current page processing
            Response.End();
        }
        finally
        {
            // Close the PDF document
            if (pdfDocument != null)
                pdfDocument.Close();
        }
    }
