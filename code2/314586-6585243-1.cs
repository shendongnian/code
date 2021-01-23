    class PrintSpooler : Queue<IPrintLabel>
    {
      public void PrintLabels()
      {
        // Establish a PrintDocument and bind to the PrintPage method something like:
        printDoc.PrintPage += (s, e) =>
        {
          IPrintLabel nextLabel = base.Dequeue();
          nextLabel.GenerateLabel(ref e);
          e.hasMorePages = (base.Count > 0);
        };
      }
    }
