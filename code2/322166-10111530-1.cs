    public static Bitmap Grayscale(Bitmap bitmap)
    {
        //Declare myBitmap as a new Bitmap with the same Width & Height
        Bitmap myBitmap = new Bitmap(bitmap.Width, bitmap.Height);
        for (int i = 0; i < bitmap.Width; i++)
        {
            for (int x = 0; x < bitmap.Height; x++)
            {
                //Get the Pixel 
                Color BitmapColor = bitmap.GetPixel(i, x);
                //I want to come back here at some point and understand, then change, the constants
                //Declare grayScale as the Grayscale Pixel
                int grayScale = (int)((BitmapColor.R * 0.3) + (BitmapColor.G * 0.59) + (BitmapColor.B * 0.11));
                //Declare myColor as a Grayscale Color
                Color myColor = Color.FromArgb(grayScale, grayScale, grayScale);
                //Set the Grayscale Pixel
                myBitmap.SetPixel(i, x, myColor);
            }
        }
        return myBitmap;
    }
