    public static void ProcessPixelValues(Image image, Action<int, int, byte> processPixelValue)
    {
        for (int x = 0; x < image.Width; x++)
        {
            for (int y = 0; y < image.Height; y++)
            {
                byte pixelValue = Convert.ToByte(Byte.MaxValue * image.GetPixel(x,         y).GetBrightness());
                processPixelValue(x, y, pixelValue);
            }
        }
    }
    public static void PrintPixelValuesOfImage(Image image)
    {
        Action<int, int, byte> processPixelValue = 
            (x, y, pixelValue) => Console.WriteLine("The pixel value of [{0},{1}] is {2}", x, y, pixelValue);
        ProcessPixelValues(image, processPixelValue);
    }
