    // Calculate the Size at which the image width and height is lower than the specified value
    // (Keep the aspect ratio)
    private static Size CalculateDimensions(Size size, int targetSize)
    {
        double rate = Math.Max(size.Width * 1.0 / targetSize, size.Height * 1.0 / targetSize);
        int w = (int)Math.Floor(size.Width / rate);
        int h = (int)Math.Floor(size.Height / rate);
        return new Size(w, h);
    }
        
    //Convert image file to byte array
    private static byte[] ConvertToBytes(string fileName)
    {
        var result = File.ReadAllBytes(fileName);
        return result;
    }
