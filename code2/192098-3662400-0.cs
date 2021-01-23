    public static unsafe Image LoadImageSafe(string path)
    {
        Image ret = null;
        using (Image imgTmp = Image.FromFile(path))
        {
            ret = new Bitmap(imgTmp.Width, imgTmp.Height, imgTmp.PixelFormat);
            if (imgTmp.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                ColorPalette pal = ret.Palette;
                for (int i = 0; i < imgTmp.Palette.Entries.Length; i++)
                    pal.Entries[i] = Color.FromArgb(imgTmp.Palette.Entries[i].A,
                        imgTmp.Palette.Entries[i].R, imgTmp.Palette.Entries[i].G,
                        imgTmp.Palette.Entries[i].B);
                ret.Palette = pal;
                BitmapData bmd = ((Bitmap)ret).LockBits(new Rectangle(0, 0,
                    imgTmp.Width, imgTmp.Height), ImageLockMode.WriteOnly,
                    PixelFormat.Format8bppIndexed);
                BitmapData bmd2 = ((Bitmap)imgTmp).LockBits(new Rectangle(0, 0,
                    imgTmp.Width, imgTmp.Height), ImageLockMode.ReadOnly,
                    PixelFormat.Format8bppIndexed);
                Byte* pPixel = (Byte*)bmd.Scan0;
                Byte* pPixel2 = (Byte*)bmd2.Scan0;
                for (int Y = 0; Y < imgTmp.Height; Y++)
                {
                    for (int X = 0; X < imgTmp.Width; X++)
                    {
                        pPixel[X] = pPixel2[X];
                    }
                    pPixel += bmd.Stride;
                    pPixel2 += bmd2.Stride;
                }
                ((Bitmap)ret).UnlockBits(bmd);
                ((Bitmap)imgTmp).UnlockBits(bmd2);
            }
            else
            {
                Graphics gdi = Graphics.FromImage(ret);
                gdi.DrawImageUnscaled(imgTmp, 0, 0);
                gdi.Dispose();
            }
            imgTmp.Dispose(); // just to make sure
        }
        return ret;
    }
