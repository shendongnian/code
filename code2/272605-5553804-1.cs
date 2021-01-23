    WriteableBitmap w = new System.Windows.Media.Imaging.WriteableBitmap(this, null); // 'this' is your current page
    WriteableBitmap w2 = new System.Windows.Media.Imaging.WriteableBitmap(480, 800);
    
    // space for SysTray
    for (int i = 0; i < 32; i++)
    {
        for (int j = 0; j < 480; j++)
        {
            w2.Pixels[i * 480 + j] = -16777216; // black #ff000000
        }
    }
    
    // actual client area
    for (int i = 32; i < 728; i++)
    {
        for (int j = 0; j < 480; j++)
        {
            w2.Pixels[i * 480 + j] = w.Pixels[(i - 32) * 480 + j];
        }
    }
    
    // space for AppBar
    for (int i = 728; i < 800; i++)
    {
        for (int j = 0; j < 480; j++)
        {
            w2.Pixels[i * 480 + j] = -16777216; // black #ff000000
        }
    }
    MemoryStream ms = new MemoryStream();
    w2.SaveJpeg(ms, 480, 800, 0, 100);
    Microsoft.Xna.Framework.Media.MediaLibrary lib = new Microsoft.Xna.Framework.Media.MediaLibrary();
    ms.Position = 0;
    lib.SavePicture("screenshot", ms);
