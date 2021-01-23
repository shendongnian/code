    class Program
    {
        static void Main(string[] args)
        {
            var names = Enumerable.Range(1, 10000).Select(i => i.ToString()).ToList();
            var namesHash = new HashSet<string>(names);
            string testName = "9999";
            for (int i = 0; i < 10; i++)
            {
                Profiler.ReportRunningTimes(new Dictionary<string, Action>() 
                {
                    { "Enumerable.Any", () => ExecuteContains(names, testName, ContainsAny) },
                    { "ICollection.Contains", () => ExecuteContains(names, testName, ContainsCollection) },
                    { "Foreach Loop", () => ExecuteContains(names, testName, ContainsLoop) },
                    { "HashSet", () => ExecuteContains(namesHash, testName, ContainsCollection) }
                },
                (s, ts) => Console.WriteLine("{0, 20}: {1}", s, ts), 10000);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        static bool ContainsAny(ICollection<string> names, string name)
        {
            return names.Any(s => s == name);
        }
        static bool ContainsCollection(ICollection<string> names, string name)
        {
            return names.Contains(name);
        }
        static bool ContainsLoop(ICollection<string> names, string name)
        {
            foreach (var currentName in names)
            {
                if (currentName == name)
                    return true;
            }
            return false;
        }
        static void ExecuteContains(ICollection<string> names, string name,
            Func<ICollection<string>, string, bool> containsFunc)
        {
            if (containsFunc(names, name))
                Trace.WriteLine("Found element in list.");
        }
    }
