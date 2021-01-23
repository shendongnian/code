    public static string ConvertHTMLtoPDF(string htmlFullPath, string pageSize, string orientation)
    {
       string pdfUrl = htmlFullPath.Replace(".html", ".pdf");
    
       try
       {
           #region USING WkHtmlToXSharp.dll
           //IHtmlToPdfConverter converter = new WkHtmlToPdfConverter();
           IHtmlToPdfConverter converter = new MultiplexingConverter();
    
           converter.GlobalSettings.Margin.Top = "0cm";
           converter.GlobalSettings.Margin.Bottom = "0cm";
           converter.GlobalSettings.Margin.Left = "0cm";
           converter.GlobalSettings.Margin.Right = "0cm";
           converter.GlobalSettings.Orientation = (PdfOrientation)Enum.Parse(typeof(PdfOrientation), orientation);
           if (!string.IsNullOrEmpty(pageSize))
               converter.GlobalSettings.Size.PageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), pageSize);
    
           converter.ObjectSettings.Page = htmlFullPath;
           converter.ObjectSettings.Web.EnablePlugins = true;
           converter.ObjectSettings.Web.EnableJavascript = true;
           converter.ObjectSettings.Web.Background = true;
           converter.ObjectSettings.Web.LoadImages = true;
           converter.ObjectSettings.Load.LoadErrorHandling = LoadErrorHandlingType.ignore;
    
           Byte[] bufferPDF = converter.Convert();
    
           System.IO.File.WriteAllBytes(pdfUrl, bufferPDF);
    
           converter.Dispose();
           
           #endregion
       }
       catch (Exception ex)
       {
           throw new Exception(ex.Message, ex);
       }
    
       return pdfUrl;
    }
