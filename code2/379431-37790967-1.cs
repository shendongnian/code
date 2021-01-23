    int cropX, cropY, cropWidth, cropHeight;
            //here rectangle border pen color=red and size=2;
            Pen borderpen = new Pen(Color.Red, 2);
            System.Drawing.Image _orgImage;
            Bitmap crop;
           
            //fill the rectangle color =white
            SolidBrush rectbrush = new SolidBrush(Color.FromArgb(100, Color.White));
    
     private void pic_scan_MouseDown(object sender, MouseEventArgs e)
            {
                try
                {
                    if (e.Button == MouseButtons.Left)//here i have use mouse click left button only
                    {
                        pic_scan.Refresh();
                        cropX = e.X;
                        cropY = e.Y;
                        Cursor = Cursors.Cross;
                    }
                    pic_scan.Refresh();
                }
                catch { }
            }
     private void pic_scan_MouseMove(object sender, MouseEventArgs e)
            {
                try
                {
                    if (pic_scan.Image == null)
                        return;
    
                    if (e.Button == MouseButtons.Left)//here i have use mouse click left button only
                    {
                        pic_scan.Refresh();
                        cropWidth = e.X - cropX;
                        cropHeight = e.Y - cropY;
                    }
                    pic_scan.Refresh();
                }
                catch { }
            }
    
            private void pic_scan_MouseUp(object sender, MouseEventArgs e)
            {
                try
                {
                    Cursor = Cursors.Default;
                    if (cropWidth < 1)
                    {
                        return;
                    }
                    System.Drawing.Rectangle rect = new System.Drawing.Rectangle(cropX, cropY, cropWidth, cropHeight);
                    Bitmap bit = new Bitmap(pic_scan.Image, pic_scan.Width, pic_scan.Height);
                    crop = new Bitmap(cropWidth, cropHeight);
                    Graphics gfx = Graphics.FromImage(crop);
                    gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;//here add  System.Drawing.Drawing2D namespace;
                    gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;//here add  System.Drawing.Drawing2D namespace;
                    gfx.CompositingQuality = CompositingQuality.HighQuality;//here add  System.Drawing.Drawing2D namespace;
                    gfx.DrawImage(bit, 0, 0, rect, GraphicsUnit.Pixel);
                   
                }
                catch { }
            }
    
            private void pic_scan_Paint(object sender, PaintEventArgs e)
            {
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(cropX, cropY, cropWidth, cropHeight);
                Graphics gfx = e.Graphics;
                gfx.DrawRectangle(borderpen, rect);
                gfx.FillRectangle(rectbrush, rect);
            }
