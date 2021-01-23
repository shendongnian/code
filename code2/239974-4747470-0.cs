    Bitmap img = (Bitmap) Image.FromFile(imageFileName);
    BitmapData data = img.LockBits(new Rectangle(0,0,img.Width, img.Height), ImageLockMode.ReadWrite, img.PixelFormat);
    byte* ptr = (byte*) data.Scan0;
    for (int j = 0; j &lt; data.Height; j++)
    {
        byte* scanPtr = ptr + (j * data.Stride);
        for (int i = 0; i &lt; data.Stride; i++, scanPtr++)
        {
            Console.WriteLine(*scanPtr); // this is value of each channel
        }
    }
    img.UnlockBits(data);
