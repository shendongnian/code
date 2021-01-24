    using (var image = new MagickImage())
    {
        private MagickReadSettings _settings;
    
        _settings = new MagickReadSettings()
        {
           FrameCount = 1, // return only one page
        };
    
        _settings.FrameIndex = 1; // return only the first page
        _settings.Density = new Density(resolution); // set the resolution
    
        image.Read(DocPath, _settings);
        image.ColorAlpha(MagickColors.White);
                            
        bmp = image.ToBitmap();
    }
