    //Get local print server
    var server = new LocalPrintServer();
    
    //Load queue for correct printer
    PrintQueue queue = server.GetPrintQueue(PrinterName, new string[0] { }); 
    //Check some properties of printQueue    
    bool isInError = queue.IsInError;
    bool isOutOfPaper = queue.IsOutOfPaper;
    bool isOffline = queue.IsOffline;
    bool isBusy = queue.IsBusy;
