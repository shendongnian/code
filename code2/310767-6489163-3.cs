        private static void GetCount(int[,] Positions)
        {
            var range = Enumerable.Range(0, Positions.Length / 2);
            var result = (range.Select(i => Positions[i, 0]).Distinct().Count() * 8) +
                         (range.Select(i => Positions[i, 1]).Distinct().Count() * 8);
            Console.WriteLine(result);
            
        }
