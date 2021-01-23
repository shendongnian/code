    // Controls if the current HTML page will be rendered to PDF or as a normal page
    bool convertToPdf = false;
    
    protected void convertToPdfButton_Click(object sender, EventArgs e)
    {
        // The current ASP.NET page will be rendered to PDF when its Render method will be called by framework
        convertToPdf = true;
    }
    
    protected override void Render(HtmlTextWriter writer)
    {
        if (convertToPdf)
        {
            // Get the current page HTML string by rendering into a TextWriter object
            TextWriter outTextWriter = new StringWriter();
            HtmlTextWriter outHtmlTextWriter = new HtmlTextWriter(outTextWriter);
            base.Render(outHtmlTextWriter);
    
            // Obtain the current page HTML string
            string currentPageHtmlString = outTextWriter.ToString();
    
            // Create a HTML to PDF converter object with default settings
            HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();
    
            // Set license key received after purchase to use the converter in licensed mode
            // Leave it not set to use the converter in demo mode
            htmlToPdfConverter.LicenseKey = "fvDh8eDx4fHg4P/h8eLg/+Dj/+jo6Og=";
                    
            // Use the current page URL as base URL
            string baseUrl = HttpContext.Current.Request.Url.AbsoluteUri;
    
            // Convert the current page HTML string a PDF document in a memory buffer
            byte[] outPdfBuffer = htmlToPdfConverter.ConvertHtml(currentPageHtmlString, baseUrl);
    
            // Send the PDF as response to browser
    
            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");
    
            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Convert_Current_Page.pdf; size={0}", outPdfBuffer.Length.ToString()));
    
            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);
    
            // End the HTTP response and stop the current page processing
            Response.End();
        }
        else
        {
            base.Render(writer);
        }
    }
