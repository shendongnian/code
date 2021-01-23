    private System.Drawing.Bitmap _bitmapFromSource(BitmapSource bitmapsource) 
    { 
        System.Drawing.Bitmap bitmap; 
        using (MemoryStream outStream = new MemoryStream()) 
        { 
            // from System.Media.BitmapImage to System.Drawing.Bitmap 
            BitmapEncoder enc = new BmpBitmapEncoder(); 
            enc.Frames.Add(BitmapFrame.Create(bitmapsource)); 
            enc.Save(outStream); 
            bitmap = new System.Drawing.Bitmap(outStream); 
        } 
        return bitmap; 
    } 
