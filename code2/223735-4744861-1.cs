    static void Main(string[] args)
    {
        DateTime start = DateTime.Now;
        List<string> names = new List<string>();
        Enumerable.Range(1, 1000).ToList().ForEach(c => names.Add("Name  = " + c.ToString()));
        for (int i = 0; i < 100; i++)
        {
            //For the for loop. Uncomment the other when you want to profile foreach loop
            //and comment this one
            //for (int j = 0; j < names.Count; j++)
              //  Console.WriteLine(names[j]);
            //for the foreach loop
            foreach (string n in names)
            {
                Console.WriteLine(n);
            }
        }
        DateTime end = DateTime.Now;
        Console.WriteLine("Time taken = " + end.Subtract(start).TotalMilliseconds + " milli seconds");
