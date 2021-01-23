    Image imgToResize = Image.FromFile(@"Dejeuner.jpg");
    Size size = new Size(768, 1024);
    Bitmap b = new Bitmap(size.Width, size.Height);
    
    Graphics g = Graphics.FromImage((Image)b);
    g.FillRectangle(Brushes.Green, 0, 0, size.Width, size.Height);
    
    Bitmap b2 = new Bitmap(768 + 8, 570 + 8);
    {
        Graphics g2 = Graphics.FromImage((Image)b2);
        g2.Clear(Color.White);
        g2.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g2.DrawImage(imgToResize, new Rectangle(2, 2, 768 + 4, 570 + 4));
    }
    g.CompositingMode = CompositingMode.SourceCopy;
    g.DrawImage(b2, 0, 150, new Rectangle(4, 4, 768, 570), GraphicsUnit.Pixel);
    b.Save("sized_HighQualityBicubic.jpg");
