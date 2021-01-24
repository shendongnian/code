    class Program
    {
        static void Main(string[] args)
        {
            var word = "indivisibility";
            Console.WriteLine($"{word} has {CountDuplicates(word)} duplicates.");
            word = "Indivisibilities";
            Console.WriteLine($"{word} has {CountDuplicates(word)} duplicates.");
            word = "aA11";
            Console.WriteLine($"{word} has {CountDuplicates(word)} duplicates.");
            word = "ABBA";
            Console.WriteLine($"{word} has {CountDuplicates(word)} duplicates.");
            Console.ReadLine();
        }
        public static int CountDuplicates(string str) =>
            (from c in str.ToLower()
             group c by c
             into grp
             where grp.Count() > 1
             select grp.Key).Count();
    }
Here's the output:
indivisibility has 1 duplicates.
Indivisibilities has 2 duplicates.
aA11 has 2 duplicates.
ABBA has 2 duplicates.
Hope this helps.
