    public static void Main(string[] args)
    {
        MemoryStream ms = new MemoryStream();
        // You have a PNGBitmapEncoder, and you call this:
        encoder.Save(ms);
        byte[] image = new byte[ms.Length];
        Buffer.BlockCopy(ms.GetBuffer(), 0, image, 0, (int)ms.Length);
        for (int i = 0; i < ms.Length; i++)
            Console.WriteLine(image[i]);
        Console.ReadKey();
    }
