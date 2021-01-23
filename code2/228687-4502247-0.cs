        static void Main(string[] args)
        {
            uint n = uint.Parse(Console.ReadLine());
            uint m = uint.Parse(Console.ReadLine());
            int[,] array = new int[n, m];
            FillArrayMethodC(array); 
        }
        static void FillArrayMethodC(int[,] arr)
        {
            int numRows = arr.GetLength(0);
            int numCols = arr.GetLength(1);
            for (int i = 0; i < numRows; i++)
                for (int j = 0; j < numCols; j++)
                {
                    // Fill your array here, e.g.:
                    arr[i, j] = i * j;
                }
            return; 
        }
