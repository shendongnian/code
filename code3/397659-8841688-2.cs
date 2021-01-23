    PrintAction printAction = PrintAction.PrintToFile;
    
    private void printDocument_BeginPrint(object sender, PrintEventArgs e)
    {
        // Save our print action so we know if we are printing 
        // a preview or a real document.
        printAction = e.PrintAction;
    
        // We ALWAYS want true here, as we will implement the 
        // margin limitations later in code.
        printDocument.OriginAtMargins = true;
    
        // Set some preferences, our method should print a box with any 
        // combination of these properties being true/false.
        printDocument.DefaultPageSettings.Landscape = false;
        printDocument.DefaultPageSettings.Margins.Top = 100;
        printDocument.DefaultPageSettings.Margins.Left = 0;
        printDocument.DefaultPageSettings.Margins.Right = 50;
        printDocument.DefaultPageSettings.Margins.Bottom = 0;
    }
    
    private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
    {
        Graphics g = e.Graphics;
    
        // If you set printDocumet.OriginAtMargins to 'false' this event 
        // will print the largest rectangle your printer is physically 
        // capable of. This is often 1/8" - 1/4" from each page edge.
        // ----------
        // If you set printDocument.OriginAtMargins to 'false' this event
        // will print the largest rectangle permitted by the currently 
        // configured page margins. By default the page margins are 
        // usually 1" from each page edge but can be configured by the end
        // user or overridden in your code.
        // (ex: printDocument.DefaultPageSettings.Margins)
    
        // Grab a copy of our "hard margins" (printer's capabilities) 
        // This varies between printer models. Software printers like 
        // CutePDF will have no "physical limitations" and so will return 
        // the full page size 850,1100 for a letter page size.
        RectangleF printableArea = e.PageSettings.PrintableArea;
        RectangleF realPrintableArea = new RectangleF(
            (e.PageSettings.Landscape ? printableArea.Y : printableArea.X),
            (e.PageSettings.Landscape ? printableArea.X : printableArea.Y),
            (e.PageSettings.Landscape ? printableArea.Height : printableArea.Width),
            (e.PageSettings.Landscape ? printableArea.Width : printableArea.Height)
            );
    
        // If we are printing to a print preview control, the origin won't have 
        // been automatically adjusted for the printer's physical limitations. 
        // So let's adjust the origin for preview to reflect the printer's 
        // hard margins.
        // ----------
        // Otherwise if we really are printing, just use the soft margins.
        g.TranslateTransform(
            ((printAction == PrintAction.PrintToPreview) ? realPrintableArea.X : 0) - e.MarginBounds.X,
            ((printAction == PrintAction.PrintToPreview) ? realPrintableArea.Y : 0) - e.MarginBounds.Y
        );
    
        // Draw the printable area rectangle in PURPLE
        Rectangle printedPrintableArea = Rectangle.Truncate(realPrintableArea);
        printedPrintableArea.Width--;
        printedPrintableArea.Height--;
        g.DrawRectangle(Pens.Purple, printedPrintableArea);
    
        // Grab a copy of our "soft margins" (configured printer settings)
        // Defaults to 1 inch margins, but could be configured otherwise by 
        // the end user. You can also specify some default page margins in 
        // your printDocument.DefaultPageSetting properties.
        RectangleF marginBounds = e.MarginBounds;
    
        // This intersects the desired margins with the printable area rectangle. 
        // If the margins go outside the printable area on any edge, it will be 
        // brought in to the appropriate printable area.
        marginBounds.Intersect(realPrintableArea);
    
        // Draw the margin rectangle in RED
        Rectangle printedMarginArea = Rectangle.Truncate(marginBounds);
        printedMarginArea.Width--;
        printedMarginArea.Height--;
        g.DrawRectangle(Pens.Red, printedMarginArea);
    }
