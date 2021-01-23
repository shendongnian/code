    IHtmlToPdfConverter converter = new MultiplexingConverter();
    
    converter.ObjectSettings.Page = htmlFullPath;
    
    converter.ObjectSettings.Web.EnablePlugins = true;
    converter.ObjectSettings.Web.EnableJavascript = true;
    converter.ObjectSettings.Web.Background = true;
    converter.ObjectSettings.Web.LoadImages = true;
    converter.ObjectSettings.Load.LoadErrorHandling = LoadErrorHandlingType.ignore;
    
    converter.GlobalSettings.Orientation = (PdfOrientation)Enum.Parse(typeof(PdfOrientation), orientation);
    if (!string.IsNullOrEmpty(pageSize))
        converter.GlobalSettings.Size.PageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), pageSize);
    
    converter.GlobalSettings.Margin.Top = "0cm";
    converter.GlobalSettings.Margin.Bottom = "0cm";
    converter.GlobalSettings.Margin.Left = "0cm";
    converter.GlobalSettings.Margin.Right = "0cm";
    
    Byte[] bufferPDF = converter.Convert();
    
    System.IO.File.WriteAllBytes(pdfUrl, bufferPDF);
    
    converter.Dispose();
    converter = null;
