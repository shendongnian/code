    string s1 = "Hello";
    string s2 = "Hello world";
    
    s2=  s2.Replace(s1, "");
    Bitmap bmap = new Bitmap(150, 25);
    Graphics graphic = Graphics.FromImage(bmap);
                
    graphic.DrawString(s1, new Font(FontFamily.GenericSerif, 8), new SolidBrush(Color.White), new PointF());
    graphic.DrawString(s2, new Font(FontFamily.GenericSerif, 8), new SolidBrush(Color.Yellow), new PointF());
    bmap.Save("myimage.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
