    static void Main(string[] args)
    {
        int x = 0;
        int count = 0;
        String[] line = new string[] { "123", "456", "123" }; //File.ReadAllLines("C:/num.txt");
        int n = line.Length;
        String[] res = new String[n];
        string previous = null;
        Array.Sort(line); // Ensures that equal values are adjacent
        for (int i = 0; i < n; i++)
        {
            string consider = line[i].Trim(); // Note leading whitespace will break this.
            if (consider != previous)
            {
                previous = consider;
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
