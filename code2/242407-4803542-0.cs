    Bitmap b = new Bitmap(100, 100);
    using (var g = Graphics.FromImage(b))
    {
        g.DrawString("Hello", this.Font, Brushes.Black, new PointF(0, 0));
    }
    PrintDocument pd = new PrintDocument();
    pd.PrintPage += (object printSender, PrintPageEventArgs printE) =>
        {
            printE.Graphics.DrawImageUnscaled(b, new Point(0, 0));
        };
    PrintDialog dialog = new PrintDialog();
    dialog.ShowDialog();
    pd.PrinterSettings = dialog.PrinterSettings;
    pd.Print();
