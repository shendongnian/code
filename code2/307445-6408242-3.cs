    static void Main(string[] args)
    {
        using (var ff = new MemoryStream())
        using (var f = new StreamWriter(ff))
        {
            f.AutoFlush = true;
            f.WriteLine("Hi");
            using (TextReader ts = new StreamReader(ff))
            {
            }
        }
    }
