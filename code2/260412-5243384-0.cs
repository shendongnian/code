    Bitmap mg = new Bitmap(strUploadPath);
    Size newSize = new Size(Convert.ToInt32(DispMaxWidth), Convert.ToInt32(DispMaxHeight));
    Bitmap bp = ResizeImage(mg, newSize);
    if (bp != null)
    bp.Save(strUploadPath, System.Drawing.Imaging.ImageFormat.Jpeg);
    private Bitmap ResizeImage(Bitmap mg, Size newSize)
            {
                double ratio = 0d;
                double myThumbWidth = 0d;
                double myThumbHeight = 0d;
                int x = 0;
                int y = 0;
    
                Bitmap bp;
    
                if ((mg.Width / Convert.ToDouble(newSize.Width)) > (mg.Height /
                Convert.ToDouble(newSize.Height)))
                    ratio = Convert.ToDouble(mg.Width) / Convert.ToDouble(newSize.Width);
                else
                    ratio = Convert.ToDouble(mg.Height) / Convert.ToDouble(newSize.Height);
                myThumbHeight = Math.Ceiling(mg.Height / ratio);
                myThumbWidth = Math.Ceiling(mg.Width / ratio);
    
                //Size thumbSize = new Size((int)myThumbWidth, (int)myThumbHeight);
                Size thumbSize = new Size((int)newSize.Width, (int)newSize.Height);
                bp = new Bitmap(newSize.Width, newSize.Height);
                x = (newSize.Width - thumbSize.Width) / 2;
                y = (newSize.Height - thumbSize.Height);
                // Had to add System.Drawing class in front of Graphics ---
                System.Drawing.Graphics g = Graphics.FromImage(bp);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                Rectangle rect = new Rectangle(x, y, thumbSize.Width, thumbSize.Height);
                g.DrawImage(mg, rect, 0, 0, mg.Width, mg.Height, GraphicsUnit.Pixel);
    
                return bp;
    
            }
