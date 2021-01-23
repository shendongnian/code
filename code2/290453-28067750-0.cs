        public void SaveBitmap(System.Windows.Forms.Panel CtrlToSave, string fileName)
        {
            Point oldPosition = new Point(this.HorizontalScroll.Value, this.VerticalScroll.Value);
            ComposedImage ci = new ComposedImage(new Size(CtrlToSave.DisplayRectangle.Width, CtrlToSave.DisplayRectangle.Height));
            
            int visibleWidth = CtrlToSave.Width - (CtrlToSave.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0);
            int visibleHeightBuffer = CtrlToSave.Height - (CtrlToSave.HorizontalScroll.Visible ? SystemInformation.HorizontalScrollBarHeight : 0);
            //int Iteration = 0;
            
            for (int x = CtrlToSave.DisplayRectangle.Width-visibleWidth; x >= 0 ; x -= visibleWidth)
            {
                CtrlToSave.PerformLayout();
                int visibleHeight = visibleHeightBuffer;
                for (int y = CtrlToSave.DisplayRectangle.Height-visibleHeight; y >= 0 ; y -= visibleHeight)
                {
                    CtrlToSave.HorizontalScroll.Value = x;
                    CtrlToSave.VerticalScroll.Value = y;
                    CtrlToSave.PerformLayout();
                    Bitmap bmp = new Bitmap(visibleWidth, visibleHeight);
                    
                    CtrlToSave.DrawToBitmap(bmp, new Rectangle(0, 0, visibleWidth, visibleHeight));
                    ci.images.Add(new ImagePart(new Point(x,y),bmp));
                    ///Show image parts
                    //using (Graphics grD = Graphics.FromImage(bmp))
                    //{
                    //    Iteration++;
                    //    grD.DrawRectangle(Pens.Blue,new Rectangle(0,0,bmp.Width-1,bmp.Height-1));
                        //grD.DrawString("x:"+x+",y:"+y+",W:"+visibleWidth+",H:"+visibleHeight + " I:" + Iteration,new Font("Segoe UI",9f),Brushes.Red,new Point(2,2));                        
                    //}
                    if (y - visibleHeight < (CtrlToSave.DisplayRectangle.Height % visibleHeight))
                        visibleHeight = CtrlToSave.DisplayRectangle.Height % visibleHeight;
                    
                    if (visibleHeight == 0)
                        break;
                }
                if (x - visibleWidth < (CtrlToSave.DisplayRectangle.Width % visibleWidth))
                    visibleWidth = CtrlToSave.DisplayRectangle.Width % visibleWidth;                
                if (visibleWidth == 0)
                    break;
            }
            Bitmap img = ci.composeImage();
            img.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
            CtrlToSave.HorizontalScroll.Value = oldPosition.X;
            CtrlToSave.VerticalScroll.Value = oldPosition.Y;
        }
    
    public class ComposedImage
    {
        public Size dimensions;
        public List<ImagePart> images;
        public ComposedImage(Size dimensions)
        {
            this.dimensions = dimensions;
            this.images = new List<ImagePart>();
        }
        public ComposedImage(Size dimensions, List<ImagePart> images)
        {
            this.dimensions = dimensions;
            this.images = images;
        }
        public Bitmap composeImage()
        {
            if (dimensions == null || images == null)
                return null;
            Bitmap fullbmp = new Bitmap(dimensions.Width, dimensions.Height);
            using (Graphics grD = Graphics.FromImage(fullbmp))
            {
                foreach (ImagePart bmp in images)
                {
                    grD.DrawImage(bmp.image, bmp.location.X, bmp.location.Y);
                }
            }
            return fullbmp;
        }
    }
    public class ImagePart
    {
        public Point location;
        public Bitmap image;
        public ImagePart(Point location, Bitmap image)
        {
            this.location = location;
            this.image = image;
        }
    }
