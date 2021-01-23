    class Program
    {
        static void Main(string[] args)
        {
            var aa = new string[] { "1", "2", "4" };
            var bb = new string[] { "1", "2", "3", "4" };
            var cc = new string[] { "2", "4" };
            //*cannot directly reference the above anymore*//
            var dd = new string[][] { aa, bb, cc };
            var result = dd[0].AsEnumerable();;
            foreach (var innerArray in dd.Skip(1))
            {
                result = result.Join(innerArray, y => y, x => x, (x, y) => x);
            }
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
