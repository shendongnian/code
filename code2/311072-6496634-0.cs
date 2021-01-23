            var bmp = new Bitmap(100, 100, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (var gr = Graphics.FromImage(bmp)) {
                gr.Clear(Color.Blue);
                gr.FillRectangle(Brushes.Red, new Rectangle(10, 10, 80, 80));
            }
            bmp.MakeTransparent(Color.Red);
            bmp.Save(@"c:\temp\test.gif", System.Drawing.Imaging.ImageFormat.Gif);
