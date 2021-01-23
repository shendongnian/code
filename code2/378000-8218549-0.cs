    static void Main(string[] args)
    {
        int x = 0;
        int count = 0;
        String[] line = new string[] { "123", "456", "123" }; //File.ReadAllLines("C:/num.txt");
        int n = line.Length;
        String[] res = new String[n];
        List<string> observedValues = new List<string>();
        for (int i = 0; i < n; i++)
        {
            string consider = line[i]; // This code crashes: .Substring(x, x + 8);
            if (!observedValues.Contains(consider))
            {
                observedValues.Add(consider);
                res[i] = consider;
                Console.WriteLine(res[i]);
            }
            else
            {
                Console.WriteLine("Skipped value: " + consider + " on line " + i);
            }
            Console.ReadLine();
        }
    }
