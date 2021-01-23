    static System.Drawing.Image FixedSize(System.Drawing.Image imgPhoto, int Width, int Height)
    {
    int sourceWidth = imgPhoto.Width;
    int sourceHeight = imgPhoto.Height;
    int sourceX = 0;
    int sourceY = 0;
    int destX = 0;
    int destY = 0;
    float nPercent = 0;
    float nPercentW = 0;
    float nPercentH = 0;
    nPercentW = ((float)Width / (float)sourceWidth);
    nPercentH = ((float)Height / (float)sourceHeight);
    if (nPercentH < nPercentW)
    {
        nPercent = nPercentH;
        destX = System.Convert.ToInt16((Width -
                      (sourceWidth * nPercent)) / 2);
    }
    else
    {
        nPercent = nPercentW;
        destY = System.Convert.ToInt16((Height -
                      (sourceHeight * nPercent)) / 2);
    }
    int destWidth = (int)(sourceWidth * nPercent);
    int destHeight = (int)(sourceHeight * nPercent);
    Bitmap bmPhoto = new Bitmap(Width, Height,
                      PixelFormat.Format24bppRgb);
    bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                     imgPhoto.VerticalResolution);
    Graphics grPhoto = Graphics.FromImage(bmPhoto);
    grPhoto.Clear(Color.White);
    grPhoto.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    grPhoto.DrawImage(imgPhoto,
        new Rectangle(destX, destY, destWidth, destHeight),
        new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
        GraphicsUnit.Pixel);
    grPhoto.Dispose();
    return bmPhoto;
