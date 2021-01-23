    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();
            var req = (HttpWebRequest)WebRequest.Create("http://localhost");
            var response = req.GetResponse();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);            
        }
    }
