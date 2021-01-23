    // Note: untested
    var dialog = new PrintDialog();
        
    Nullable<bool> print = dialog.ShowDialog();
    if (print.HasValue && print.Value)
    {
        var rd = new ReportDocument();
        rd.Load("ReportFile.rpt");
        rd.SetParameter("Parameter1", "abc");
        rd.SetParameter("Parameter2", "foo");
        rd.PrintOptions.PrinterName = dialog.PrinterSettings.PrinterName;
        rd.PrintToPrinter(1, false, 0, 0);
    }
