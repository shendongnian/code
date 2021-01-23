    void CleanPrinterQueue(string printerName)         
    {   
       using (var ps = new PrintServer())
       {
          using (var pq = new PrintQueue(ps, printerName, PrintSystemDesiredAccess.UsePrinter))
          {
             foreach (var job in pq.GetPrintJobInfoCollection())
                job.Cancel();
          }
       }
    }
