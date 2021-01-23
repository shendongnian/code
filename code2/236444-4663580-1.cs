    System.Windows.Controls.PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
    if (printDlg.ShowDialog() == true)
    {
        System.Printing.PrintCapabilities capabilities = printDlg.PrintQueue.GetPrintCapabilities(printDlg.PrintTicket);
    
        double scale = Math.Min(capabilities.PageImageableArea.ExtentWidth / control.ActualWidth, capabilities.PageImageableArea.ExtentHeight /
                       control.ActualHeight);
    
        control.LayoutTransform = new System.Windows.Media.ScaleTransform(scale, scale);
    
        Size sz = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);
    
        control.Measure(sz);
        control.Arrange(new Rect(new Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight), sz));
    
        printDlg.PrintVisual(control, "My App");
    }
