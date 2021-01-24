    using (Bitmap img = new Bitmap("truc.bmp"))
    {
        for (int x = 0; x < img.Width; x++)
        {
            for (int y = 0; y < img.Height; y++)
            {
                var m  = new MyPixel();
                m.Coord = new Point(x, y);
                m.Rgb = img.GetPixel(x,y);
                MyPixels.Add(m);
            }
        }
    
        var maxreds = MyPixels.OrderByDescending(x => x.Rfraction).Take(10);
        var maxblues = MyPixels.OrderByDescending(x => x.Bfraction).Take(10);
    }
