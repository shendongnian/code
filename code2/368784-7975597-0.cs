    Bitmap bmp new Bitmap(28, 28, System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);
    for (int i = 0; i < 28; i++)
    {
        for (int j = 0; j < 28; j++)
        {
            bmp.SetPixel(i, j, Color.FromArgb(Convert.ToInt32(test[c]), 0, 0));
            c++;
        }
    }
