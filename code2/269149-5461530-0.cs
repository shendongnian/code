    public byte[] CreateGridImage(int maxXCells, int maxYCells,
                        int cellXPosition, int cellYPosition)
    {
        int imageWidth = 1;
        int imageHeight = 2;
        Bitmap bmp = new Bitmap(imageWidth, imageHeight);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            //draw code in here
        }
        MemoryStream imageStream = new MemoryStream();
        bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        bmp.Dispose();
        return imageStream.ToArray();
    }
