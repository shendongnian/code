       string s = "string to print";
        PrintDocument p = new PrintDocument();
        p.PrintPage += delegate(object sender1, PrintPageEventArgs e1)
        {
            e1.Graphics.DrawString(s, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
        };
        try
        {
            p.Print();
        }
        catch (Exception ex)
        {
            throw new Exception("Exception Occured While Printing", ex);
        }
