    System.Printing.PrintCapabilities capabilities = 
        printDlg.PrintQueue.GetPrintCapabilities(printDlg.PrintTicket);
 
     //get scale of the print wrt to screen of WPF visual
     double scale = Math.Min(capabilities.PageImageableArea.ExtentWidth / this.ActualWidth, capabilities.PageImageableArea.ExtentHeight /
                    this.ActualHeight);
 
     //Transform the Visual to scale
     this.LayoutTransform = new ScaleTransform(scale, scale);
 
     //get the size of the printer page
     Size sz = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);
 
     //update the layout of the visual to the printer page size.
     this.Measure(sz);
     this.Arrange(new Rect(new Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight), sz));
 
      //now print the visual to printer to fit on the one page.
      printDlg.PrintVisual(this, "Code ganked from http://www.a2zdotnet.com/View.aspx?id=66");
 
