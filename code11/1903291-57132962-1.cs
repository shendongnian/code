        public static int[,] GetMatrix(IReadOnlyList<int[]> bigList)
        {
            if (bigList.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(bigList));
            var matrix = new int[bigList.Count, bigList[0].Length];
            for (var bigListIndex = 0; bigListIndex < bigList.Count; bigListIndex++)
            {
                int[] list = bigList[bigListIndex];
                for (var numberIndex = 0; numberIndex < list.Length; numberIndex++) matrix[bigListIndex, numberIndex] = list[numberIndex];
            }
            return matrix;
        }
        private static void Main(string[] args)
        {
            var biglist = new List<int[]>
            {
                new[] {1, 2, 3, 4, 5},
                new[] {5, 3, 3, 2, 1},
                new[] {3, 4, 4, 5, 2}
            };
            int[,] matrix = GetMatrix(biglist);
            for (var i = 0; i < matrix.GetLength(1); i++)
            {
                for (var j = 0; j < matrix.GetLength(0); j++)
                    Console.Write($" {matrix[j, i]} ");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
