    static void Main(string[] args)
        {
            List<string> mean = new List<string>() { "dog", "smile", "cat", "bat", "giraffe"};
            mean.RemoveAll(item => item.Contains("t"));
            mean = mean.Select(item => item.Contains("g") ? item.ToUpper() : item).ToList();
            foreach (string s in mean)
            {
                Console.WriteLine(s);
            }
        }
