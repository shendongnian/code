    // C#
    // variable to trace text to print for pagination
    private int m_nFirstCharOnPage;
    
    private void printDoc_BeginPrint(object sender,
        System.Drawing.Printing.PrintEventArgs e)
    {
        // Start at the beginning of the text
        m_nFirstCharOnPage = 0;
    }
    
    private void printDoc_PrintPage(object sender,
        System.Drawing.Printing.PrintPageEventArgs e)
    {
        // To print the boundaries of the current page margins
        // uncomment the next line:
        // e.Graphics.DrawRectangle(System.Drawing.Pens.Blue, e.MarginBounds);
        
        // make the RichTextBoxEx calculate and render as much text as will
        // fit on the page and remember the last character printed for the
        // beginning of the next page
        m_nFirstCharOnPage = myRichTextBoxEx.FormatRange(false,
                                                e,
                                                m_nFirstCharOnPage,
                                                myRichTextBoxEx.TextLength);
    
    // check if there are more pages to print
        if (m_nFirstCharOnPage < myRichTextBoxEx.TextLength)
            e.HasMorePages = true;
        else
            e.HasMorePages = false;
    }
    
    private void printDoc_EndPrint(object sender,
        System.Drawing.Printing.PrintEventArgs e)
    {
        // Clean up cached information
        myRichTextBoxEx.FormatRangeDone();
    }
