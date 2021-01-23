    while ((line = sr.ReadLine()) != null) 
    { 
        Bitmap T = null;
        try
        {
            MemoryStream ms = new MemoryStream()) 
            try
            { 
                Bitmap B = new Bitmap(line);
                try
                { 
                    Point p = SomeMethod(ref c, new Point()); 
                    B.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                }
                finally 
                {
                    B.Dispose();
                }
 
                T = new Bitmap(Image.FromStream(ms));
            }
            finally
            {
                m.Dispose();
            }
 
            using (Graphics g = Graphics.FromImage(T)) 
            { 
                g.DrawEllipse(new Pen(Brushes.Red, 4), p.X - 5, p.Y - 5, 10, 10); 
                FileInfo fi = new FileInfo(somepath2); 
                T.Save(Path.Combine(somepath3, fi.Name)); 
            }
        }
        finally
        {
            if (T != null)
            {
                T.Dispose();
            } 
        }
    } 
