    class Program
            {
                static void Main(string[] args)
                {
                    var list = new ConcurrentBag<string>();
                    for (int i = 0; i <= 1000; i++)
                    {
                        list.Add(i.ToString());
                    }
                    var result = list.AsParallel().Where(q => Convert(q) < 500).Select(x => Convert(x)).ToList();            
                }
        
                static int Convert(string x)
                {
                    var i = 0;
                    return int.TryParse(x, out i) ? i : 0;
                }
            }
