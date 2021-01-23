      private void SnapShotPNG(ListView source, string destination)
            {
                var lastHeight = source.Height;
                source.Height = 10000;
                Graphics canvas = source.CreateGraphics();            
                Bitmap bmp = new Bitmap(1000, 1000, canvas);
                source.DrawToBitmap(bmp, new Rectangle(0, 0, 1000, 1000));
                bmp.Save(destination);
                source.Height = lastHeight;
            }
