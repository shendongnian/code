    private void printDocument_BeginPrint(object sender, PrintEventArgs e)
    {
        printAction = e.PrintAction;
        printDocument.OriginAtMargins = false;
    }
    private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
    {
        Graphics g = e.Graphics;
        if (printAction != PrintAction.PrintToPreview)
            g.TranslateTransform(-e.PageSettings.HardMarginX, -e.PageSettings.HardMarginY);
        RectangleF printArea = GetBestPrintableArea(e);
        g.DrawRectangle(Pens.Red, printArea.X, printArea.Y, printArea.Width - 1, printArea.Height - 1);
    }
    public RectangleF GetBestPrintableArea(PrintPageEventArgs e)
    {
        RectangleF marginBounds = e.MarginBounds;
        RectangleF printableArea = e.PageSettings.PrintableArea;
        RectangleF pageBounds = e.PageBounds;
    
        if (e.PageSettings.Landscape)
            printableArea = new RectangleF(printableArea.Y, printableArea.X, printableArea.Height, printableArea.Width);
    
        RectangleF bestArea = RectangleF.FromLTRB(
            (float)Math.Max(marginBounds.Left, printableArea.Left),
            (float)Math.Max(marginBounds.Top, printableArea.Top),
            (float)Math.Min(marginBounds.Right, printableArea.Right),
            (float)Math.Min(marginBounds.Bottom, printableArea.Bottom)
        );
    
        float bestMarginX = (float)Math.Max(bestArea.Left, pageBounds.Right - bestArea.Right);
        float bestMarginY = (float)Math.Max(bestArea.Top, pageBounds.Bottom - bestArea.Bottom);
    
        bestArea = RectangleF.FromLTRB(
            bestMarginX,
            bestMarginY,
            pageBounds.Right - bestMarginX,
            pageBounds.Bottom - bestMarginY
        );
    
        return bestArea;
    }
