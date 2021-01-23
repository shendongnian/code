    using (var fs = new System.IO.FileStream("c:\\path to file.bmp", System.IO.FileMode.Open))
    {
        var bmp = new Bitmap(fs);
        pct.Image = (Bitmap) bmp.Clone();
    }
