        public static void ResizeBidimArrayWithElements<T>(ref T[,] original, int rows, int cols)
        {
            T[,] newArray = new T[rows, cols];
            int minX = Math.Min(original.GetLength(0), newArray.GetLength(0));
            int minY = Math.Min(original.GetLength(1), newArray.GetLength(1));
            for (int i = 0; i < minX; ++i)
                Array.Copy(original, i * original.GetLength(1), newArray, i * newArray.GetLength(1), minY);
            original = newArray;
        }
