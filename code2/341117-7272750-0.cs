        static void Main(string[] args)
        {
            int[] i = new int[] { 1, 2, 3, 4, 5 };
            int[] j = new int[] { 5, 6, 7, 8, 9 };
            int[] k = new int[] { 0, 6, 7, 8, 9 };
            bool jContainsI = i.Any(iElement => j.Contains(iElement));
            bool kContainsI = i.Any(iElement => k.Contains(iElement));
            Console.WriteLine(jContainsI); // true
            Console.WriteLine(kContainsI); // false
            Console.Read();
        }
