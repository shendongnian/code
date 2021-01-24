cs
private void Print()
{
    var printQueue = LocalPrintServer.GetDefaultPrintQueue()
    var printTicket = printQueue.DefaultPrintTicket;
    var writer = PrintQueue.CreateXpsDocumentWriter(printQueue);
    writer.WritingCompleted += OnDocumentWritten;
    writer.WriteAsync(View.LabelPageView.AddressLabelPage, printTicket);
}
It does however seem odd, that the code worked on Windows 10 but not Windows 8.1.
