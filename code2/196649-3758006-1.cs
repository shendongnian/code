    class Program
    {
        static void Main(string[] args)
        {
            List<string> MyList = new List<string>
            { 
                "A-B", 
                "B-A", 
                "C-D", 
                "C-E", 
                "D-C",
                "D-E",
                "E-C",
                "E-D",
                "F-G",
                "G-F"
            };
            var distinct = MyList.Distinct(new CharComparer());
            foreach (string s in distinct)
                Console.WriteLine(s);
            Console.ReadLine();
        }
    }
