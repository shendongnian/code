    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var reader = new StreamReader("names.txt"))
                {
                    var names = GetNames(reader).ToLookup(k => k);
                    using (var writer = new StreamWriter("names.counted.csv"))
                    {
                        foreach (var name in names)
                        {
                            writer.WriteLine($"{name.Key},{name.Count()}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
        }
        static IEnumerable<string> GetNames(TextReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
                yield return line;
        }
    }
