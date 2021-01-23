    interface IPrintLabel
    {
      // Get or set the printer this label should print from
      // I typically bounce between a Zebra (UPS/FedEx) printer and an in-house
      // DYNO printer, depending the label I print for shipping.
      PrinterSettings PrinterSettings { get; set; }
      // Get or set the paper size, margins, etc. Allows me to setup the canvas
      PageSettings PageSettings { get; set; }
      // Method responsible for laying out the label (send it the event args
      // from the PrintPage method of PrintDocument)
      void GenerateLabel(ref PrintPageEventArgs printArgs);
      
    }
