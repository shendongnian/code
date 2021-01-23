    internal Bitmap LiveImage;
    
    int ISampleGrabberCB.BufferCB(double bufferSize, IntPtr pBuffer, int bufferLen)
    {
        using (LiveImage = new Bitmap(_width, _height, _stride, PixelFormat.Format24bppRgb, pBuffer))
        {
            LiveImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
            if (ExpImg) // local bool, used rarely when the picture saving is triggered
            {
                var a = LiveImage.Clone(new Rectangle(Currect.Left, Currect.Top, Currect.Width, Currect.Height),
                                        LiveImage.PixelFormat);
                using (a)
                    a.Save("ocr.bmp", ImageFormat.Bmp);
            }
        }
    
        return 0;
    }
