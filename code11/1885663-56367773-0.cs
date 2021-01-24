    var printers = new List<object>();
    var printerTasks = printers.Select(printer =>
    {
         if (printer == "ZJ-58")
         {
              return printer.print();
         }
         if (printer == "ZJ-58-2")
         {
              return printer.print();
         }
     });
     Task.WaitAll(printerTasks);
