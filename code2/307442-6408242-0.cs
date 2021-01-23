    static void Main(string[] args)
    {
        using (var ff = new MemoryStream())
        using (var f = new StreamWriter(ff))
        using (TextReader ts = new StreamReader(ff))
        {
            f.WriteLine("Hi");
        }
    }
