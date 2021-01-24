    static void Main(string[] args)
    {
        var objMediaInfo = new MediaInfo();
        objMediaInfo.Open(@"TheFullPathOf\test.mp4");
        string result = objMediaInfo.Inform();
        objMediaInfo.Close();
    
        Console.WriteLine(result);
        Console.ReadKey();
    }
