    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        using (var resourceImg = new Bitmap(10, 10))
        {
            using (var g = Graphics.FromImage(resourceImg))
            {
                g.FillRectangle(Brushes.Black, 0, 0, 
                    resourceImg.Width, resourceImg.Height);
            }
            var drawingArea = new Rectangle(0, 0, 200, 200);
            e.Graphics.FillRectangle(Brushes.Aqua, drawingArea);
            using (var attribs = new ImageAttributes())
            {
                attribs.SetWrapMode(WrapMode.TileFlipXY);
                e.Graphics.DrawImage(resourceImg, drawingArea, 
                        0, 0, resourceImg.Width, resourceImg.Height, 
                        GraphicsUnit.Pixel, attribs);
            }
        }    
    }
