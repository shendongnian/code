    string pathToTiff = @"C: \Users\developer\Desktop\temp\test.tif";
    this._Image = new Image();
    FileStream ImageStream = new FileStream(pathToTiff, FileMode.Open, FileAccess.Read, 
    FileShare.Read);
    TiffBitmapDecoder ImageDecoder = new TiffBitmapDecoder(ImageStream, 
    BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                
    this._FixedDocument = new FixedDocument();
    
    if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\Image"))
    {
        File.Copy(pathToTiff, AppDomain.CurrentDomain.BaseDirectory + @"\Image", true);
    }
    
    foreach (BitmapFrame f in ImageDecoder.Frames)
    {
        this._Image = new Image();
        this._Image.Source = f.Clone(); ;
        this._Image.Stretch = Stretch.None;
        this._Image.Margin = new Thickness(20);
        this._FixedPage = new System.Windows.Documents.FixedPage();
        this._FixedPage.Width = 1000;
        this._FixedPage.Height = 1000;
        this._FixedPage.Children.Add(this._Image);
         
        this._PageContent = new System.Windows.Documents.PageContent();
        this._PageContent.Child = this._FixedPage;
        this._FixedDocument.Pages.Add(this._PageContent);
    }
    documentViewer.Document = this._FixedDocument;
