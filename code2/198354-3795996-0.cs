    Uri uri = new Uri(string.Format("memorystream://{0}", "file.xps"));
    FixedDocumentSequence seq;
    
    using (Package pack = Package.Open("file.xps", ...))
    using (StorePackage(uri, pack))  // see method below
    using (XpsDocument xps = new XpsDocument(pack, Normal, uri.ToString()))
    {
        seq = xps.GetFixedDocumentSequence();
    }
    
    DocumentPaginator paginator = seq.DocumentPaginator;
    Visual visual = paginator.GetPage(0).Visual;  // first page - loop for all
    
    FrameworkElement fe = (FrameworkElement)visual;
    
    RenderTargetBitmap bmp = new RenderTargetBitmap((int)fe.ActualWidth,
                              (int)fe.ActualHeight, 96d, 96d, PixelFormats.Default);
    bmp.Render(fe);
    
    PngBitmapEncoder png = new PngBitmapEncoder();
    png.Frames.Add(BitmapFrame.Create(bmp));
    
    using (Stream stream = File.Create("file.png"))
    {
        png.Save(stream);
    }
    public static IDisposable StorePackage(Uri uri, Package package)
    {
        PackageStore.AddPackage(uri, package);
        return new Disposer(() => PackageStore.RemovePackage(uri));
    }
    
