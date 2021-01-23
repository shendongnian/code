    public static void Main(string[] args)
    {
        byte[] test = new byte[] { 2, 5, 6, 1, 9 };
        MemoryStream ms = new MemoryStream();
        ms.Write(test, 0, 5);
        byte[] image = new byte[ms.Length];
        Buffer.BlockCopy(ms.GetBuffer(), 0, image, 0, (int)ms.Length);
        for (int i = 0; i < ms.Length; i++)
            Console.WriteLine(image[i]);
        Console.ReadKey();
    }
