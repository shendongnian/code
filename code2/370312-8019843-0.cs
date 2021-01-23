    public static class Extensions
    {
        public static IEnumerable<Tuple<string, string>> Pair(this string[] source)
        {
            for (int i = 0; i < source.Length; i += 2)
            {
                yield return Tuple.Create(source[i], source[i + 1]);
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var userinput = "start, end, start2, end2, start3, end3, start4, end4";
    
            var responses = userinput 
                            .Replace(" ", string.Empty)
                            .Split(',')
                            .Pair()
                            .AsParallel()
                            .Select(x => new Request(x.Item1, x.Item2).GetResponse());
    
            foreach (var r in responses)
            {
                // do something with the response
            }
    
            Console.ReadKey();
        }
    }
