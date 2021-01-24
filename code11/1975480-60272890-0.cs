    string printerName = "TEC B-EV4-T";
    var server = new LocalPrintServer();
    PrintQueue queue = server.GetPrintQueue(printerName , Array.Empty<string>()); 
    bool isOffline = queue.IsOffline;
    bool isBusy = queue.IsBusy;
