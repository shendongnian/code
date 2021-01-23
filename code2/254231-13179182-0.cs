    [Guid("3050f669-98b5-11cf-bb82-00aa00bdce0b"),InterfaceType(ComInterfaceType.InterfaceIsIUnknown),ComVisible(true),ComImport]
    interface IHTMLElementRender
    {
      void DrawToDC([In] IntPtr hDC);
      void SetDocumentPrinter([In, MarshalAs(UnmanagedType.BStr)] string
      bstrPrinterName, [In] IntPtr hDC);
    }
    public MemoryStream CopyImage(WebBrowser webBrowser, IHTMLElement3 el, int width, int height)
    {
      MemoryStream stream = new MemoryStream();
      WebBrowser wb = webBrowser;
      IHTMLDocument3 doc = (IHTMLDocument3)wb.Document.DomDocument;
      if (doc != null)
      {
        if (el != null)
        {
         IHTMLElementRender Render = (IHTMLElementRender)el;
         Bitmap bm = new Bitmap(width, height);
         Graphics g = Graphics.FromImage(bm); 
         IntPtr hdc = g.GetHdc();
         Render.DrawToDC(hdc);
         g.ReleaseHdc(hdc);
         g.Dispose();
         Marshal.ReleaseComObject(Render);
         bm.Save(stream, ImageFormat.Bmp);
        }
      }
     return stream;
    }
