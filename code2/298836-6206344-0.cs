        static int[,] Combine(params int[][] arrays)
        {
            int[][] combined = CombineRecursive(arrays).Select(x=>x.ToArray()).ToArray();
            return JaggedToRectangular(combined);
        }
        static IEnumerable<IEnumerable<int>> CombineRecursive(IEnumerable<IEnumerable<int>> arrays)
        {
            if (arrays.Count() > 1)
                return from a in arrays.First()
                       from b in CombineRecursive(arrays.Skip(1))
                       select Enumerable.Repeat(a, 1).Union(b);
            else
                return from a in arrays.First()
                       select Enumerable.Repeat(a, 1);
        }
        static int[,] JaggedToRectangular(int[][] combined)
        {
            int length = combined.Length;
            int width = combined.Min(x=>x.Length);
            int[,] result = new int[length, width];
            
            for (int y = 0; y < length; y++)
                for (int x = 0; x < width; x++)
                    result[y, x] = combined[y][x];
            return result;
        }
