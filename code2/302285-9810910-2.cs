static void Main(string[] args)
{
    var printers = new LocalPrintServer().GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });
    PrintQueue defaultPrinter = LocalPrintServer.GetDefaultPrintQueue();
    PrintQueue printerToUse = printers.FirstOrDefault(p => p.Name.Contains("PDFCreator")) ?? defaultPrinter; // Use PDFCreator if available.
    PrintTicket ticket = printerToUse.DefaultPrintTicket;
    XpsDocumentWriter writer = PrintQueue.CreateXpsDocumentWriter(printerToUse);
    writer.Write(CreateVisual(), ticket);
}
private static Visual CreateVisual()
{
    var visual = new DrawingVisual();
    using (DrawingContext dc = visual.RenderOpen())
    {
        var pen = new Pen(Brushes.Black, 3);
        var opacityBrush = new SolidColorBrush { Color = Colors.Violet, Opacity = 0.7 };
        dc.PushClip(new RectangleGeometry(new Rect(20, 20, 150, 150)));
        dc.DrawLine(pen, new Point(0, 0), new Point(200, 300));
        dc.DrawEllipse(new SolidColorBrush(Colors.LightGreen), pen, new Point(50, 80), 50, 70);
        dc.DrawRectangle(new SolidColorBrush(Colors.LightBlue), pen, new Rect(10, 100, 100, 100));
        dc.DrawRectangle(new SolidColorBrush(Colors.LightPink), pen, new Rect(40, 120, 100, 100));
        dc.DrawRectangle(new SolidColorBrush(Colors.LightGray), pen, new Rect(60, 140, 100, 100));
        dc.DrawRectangle(opacityBrush, pen, new Rect(80, 160, 100, 100));
    }
    return visual;
}
