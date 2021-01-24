    static void Main(string[] args)
    {
        Stemmer.Cvb.Image image = new Stemmer.Cvb.Image(300, 300);
        image.Initialize(125);
        byte[] myArray = GetStemmerImageBytes(image);
        Emgu.CV.Image<Gray, Byte> test = new Image<Gray, Byte>(300, 300);
        test.Bytes = myArray;
        test.Save("D:/abc.jpg");
    }
    static unsafe byte[] GetStemmerImageBytes(Stemmer.Cvb.Image image)
    {
        int width = image.Width;
        int height = image.Height;
        var linearAccess = image.Planes[0].GetLinearAccess();
        byte* sourceBase = (byte*)linearAccess.BasePtr;
        long sourceYInc = linearAccess.YInc.ToInt64();
        long sourceXInc = linearAccess.XInc.ToInt64();
        var result = new byte[width * height];
        Parallel.For(0, height, y =>
        {
            var sourceLine = sourceBase + y * sourceYInc;
            for (int x = 0; x < width; x++)
            {
                var srcVal = *(sourceLine + x * sourceXInc);
                result[y * width + x] = srcVal;
            }
        });
        return result;
    }
