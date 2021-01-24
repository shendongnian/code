    class Program
    {
        static void Main(string[] args)
        {
            var data = new[]
            {
                12, 12, 12, 12, 12, 17, 17, 17, 17,12, 12, 12, 12, 12, 17, 17, 17, 17,17, 17, 17, 12, 12, 12, 12, 12
            };
    
            var (first, second) = SpecialSum(data);
            Console.WriteLine($"first={first},second={second}");
        }
    
        private static (int, int) SpecialSum(int[] data)
        {
            var first = 0;
            var second = 0;
            using (var e = ((IEnumerable<int>)data).GetEnumerator())
            {
                while (e.MoveNext() && e.Current != 17) ;
                do first += 17; while (e.MoveNext() && e.Current == 17);
                while (e.MoveNext() && e.Current != 17) ;
                do second += 17; while (e.MoveNext() && e.Current == 17);
                return (first, second);
            }
        }
    }
