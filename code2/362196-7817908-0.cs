    class Program
    {
        static void Main(string[] args)
        {
            int myRandomIndex = 0;
            var myList = new List<string>(new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" });
            var results = new List<string>();
            var r = new Random(DateTime.Now.Millisecond);
            for (int ii = 0; ii < 4; ii++)
            {
                myRandomIndex = r.Next(myList.Count);
                results.Add(myList[myRandomIndex]);
                myList.RemoveAt(myRandomIndex);
            }
            Console.WriteLine(string.Join("", results));
            Console.ReadKey();
        }
    }
