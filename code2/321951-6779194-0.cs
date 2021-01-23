    public void Print()
    {
        if (emfImage == null || emfImage.Count <= 0)
        {
            throw new ArgumentException("An image is required to print.");
        }
    
        printer = printer.Trim();
        if (string.IsNullOrEmpty(printer))
        {
            throw new ArgumentException("A printer is required.");
        }
    
        printingPage = 0;
        PrintDocument pd = new PrintDocument();
        pd.PrinterSettings.PrinterName = printer;
        pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
        pd.Print();
    }
    
    private void pd_PrintPage(object sender, PrintPageEventArgs e)
    {
        Metafile page = emfImage[printingPage];
        e.Graphics.DrawImage(page, 0, 0, page.Width, page.Height);
    
        e.HasMorePages = ++printingPage < emfImage.Count;
    }
