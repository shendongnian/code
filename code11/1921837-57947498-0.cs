    static void Main(string[] args)
        {
            string[] test = Regex.Split("bABa", string.Empty); // string split to an array 
            Array.Sort(test); // sort created string array 
            string sample = string.Join("", test); //rejoin string array
            Console.WriteLine(sample);
            Console.ReadLine();
        }
