        static void Main(string[] args)
        {
            List<int> lint = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("List Elements");
            lint.ForEach(delegate(int i) {  Console.WriteLine(i); });
            lint.RemoveRange(8, lint.Count - 8);
            Console.WriteLine("List Elements after removal");
            lint.ForEach(delegate(int i) { Console.WriteLine(i); });
            Console.Read();
        }
