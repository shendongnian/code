    class Program
    {
        static void Main(string[] args)
        {
            //it's up to you to get your stream
            var stream = GetStream();
            
            //Here is where you'll read your lines. 
            //Any Linq statement can be used here.
            var lines = ReadLines(stream).Skip(5).ToArray();
            //Go on and do whatever you want to do with your lines...
        }
    }
    public IEnumerable<string> ReadLines(Stream stream)
    {
        using (var reader = new StreamReader(stream))
        {
            while (!reader.EndOfStream)
            {
                yield return reader.ReadLine();
            }
        }
    }
