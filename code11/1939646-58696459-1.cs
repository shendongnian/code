        static void Main(string[] args)
        {
            var matrix = new int[,] { 
                { 1, 2, 5, 6 },
                { 3, 4, 7, 8 },
                { 4, 4, 4, 7 },
                { 4, 4, 5, 1 }
            };
            var array11 = matrix.GetSubMatrixElements(0, 0, 2, 2);
            // [1, 2, 3, 4]
            var array12 = matrix.GetSubMatrixElements(0, 2, 2, 2);
            // [5, 6, 7, 8]
            var array21 = matrix.GetSubMatrixElements(2, 0, 2, 2);
            // [4, 4, 4, 4]
            var array22 = matrix.GetSubMatrixElements(2, 2, 2, 2);
            // [4, 7, 5, 1]
        }
        public static T[] GetSubMatrixElements<T>(this T[,] matrix, int startRow, int startCol, int rowCount, int colCount)
        {
            var array = new T[rowCount*colCount];
            int index = 0;
            for (int i = startRow; i < startRow+rowCount; i++)
            {
                for (int j = startCol; j < startCol+colCount; j++)
                {
                    array[index++] = matrix[i, j];
                }
            }
            return array;
        }
