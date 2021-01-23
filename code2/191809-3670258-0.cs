    openDicom.Image.PixelData obraz = new openDicom.Image.PixelData(file.DataSet);
    Bitmap img = new System.Drawing.Bitmap(obraz.Columns, obraz.Rows, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
    int resampleval = (int)Math.Pow(2, (obraz.BitsAllocated - obraz.BitsStored));
    int pxCount = 0;
    int temp = 0;
    try
    {
        unsafe
        {
            BitmapData bd = img.LockBits(new Rectangle(0, 0, obraz.Columns, obraz.Rows), ImageLockMode.WriteOnly, img.PixelFormat);
            for (int r = 0; r < bd.Height; r++)
            {
                byte* row = (byte*)bd.Scan0 + (r * bd.Stride);
                for (int c = 0; c < bd.Width; c++)
                {
                    temp = PixelData16[pxCount] / resampleval;
                    while (temp > 255)
                        temp = temp / resampleval;
                    row[(c * 3)] = (byte)temp;
                    row[(c * 3) + 1] = (byte)temp;
                    row[(c * 3) + 2] = (byte)temp;
                    pxCount++;
                }
            }
            img.UnlockBits(bd);
        }
    }
    catch
    {
        img = new Bitmap(10, 10);
    }
    pictureBox1.Image = img;
    pictureBox1.Show();
