    private async Task Print()
    {
        using (var printQueue = LocalPrintServer.GetDefaultPrintQueue())
        {
            var printTicket = printQueue.DefaultPrintTicket;
            var writer = PrintQueue.CreateXpsDocumentWriter(printQueue);
            writer.WritingCompleted += OnDocumentWritten;
            await writer.WriteAsync(View.LabelPageView.AddressLabelPage, printTicket);
        }
    }
