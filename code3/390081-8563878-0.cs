    public void DoPrint()
    {
        var printDialog = new PrintDialog();
        if (printDialog.ShowDialog() == DialogResult.OK)
        {
            var printDocument = new PrintDocument
                {
                    DefaultPageSettings = { PrinterSettings = printDialog.PrinterSettings }
                };
            printDocument.PrintPage += OnPrintPage;
        }
    }
    private void OnPrintPage(object sender, PrintPageEventArgs e)
    {
        e.Graphics.DrawString("Hello");
    }
