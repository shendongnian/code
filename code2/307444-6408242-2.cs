        static void Main(string[] args)
        {
            using (var ff = new MemoryStream())
            using (var f = new StreamWriter(ff))
            {
                f.WriteLine("Hi");
                f.Flush();
                using (TextReader ts = new StreamReader(ff))
                {
                }
            }
        }
