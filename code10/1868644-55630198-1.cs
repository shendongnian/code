    static void Main(string[] args)
        {
            List<string> list = new List<string>()
            {
                "DFG0001D",
                "AWK0007E",
                "ORK0127E",
                "AWK0007D",
                "DFG0001E",
                "ORK0127D"
            };
            list.Sort(new CustomStringComparer(StringComparer.CurrentCulture));
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
