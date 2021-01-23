    private Bitmap renderBmp;
    public override Image BackgroundImage
    {
         set
         {
              Image baseImage = value;
              renderBmp = new Bitmap(Width, Height,
                  System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
              Graphics g = Graphics.FromImage(renderBmp);
              g.DrawImage(baseImage, 0, 0, Width, Height);
              g.Dispose();
         }
         get
         {
              return renderBmp;
         }
    } 
