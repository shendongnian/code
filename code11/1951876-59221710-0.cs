    using Ghostscript.NET.Rasterizer;
    ...
    using (GhostscriptRasterizer raster = new GhostscriptRasterizer())
    {
        raster.Open(filename);
        pages = raster.PageCount;
    
        _bitpages = new Bitmap[raster.PageCount];
        for (int i = 1; i < pages + 1; i++)
        {
            _bitpages[i - 1] = (Bitmap)raster.GetPage(dpi, dpi, i);
            // convert and save image here
        }
        raster.Close();
    }
  
