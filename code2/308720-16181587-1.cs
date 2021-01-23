    public static void MemLeak()
    {
        var src = @"C:\users\devshorts\desktop\bigImage.jpg";
        Image image1 = null;
        foreach (var i in Enumerable.Range(0, 10))
        {
            image1 = Image.FromFile(src);
        }
        image1.Dispose();
        Console.ReadLine();
    }
