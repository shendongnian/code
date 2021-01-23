    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            [DllImport(@"mydll.dll")]
            private static extern void ManagedToNative(int RowCount, int ColCount, double[] Values);
    
            [DllImport(@"mydll.dll")]
            private static extern void NativeToManaged(out int RowCount, out int ColCount, double[] Values);
    
            static double[] Flattened(int RowCount, int ColCount, double[,] arr)
            {
                double[] result = new double[RowCount*ColCount];
                int i = 0;
                for (int r = 0; r < RowCount; r++)
                    for (int c = 0; c < ColCount; c++)
                    {
                        result[i] = arr[r,c];
                        i++;
                    }
                return result;
            }
    
            static double[,] Expanded(int RowCount, int ColCount, double[] arr)
            {
                double[,] result = new double[RowCount,ColCount];
                int i = 0;
                for (int r = 0; r < RowCount; r++)
                    for (int c = 0; c < ColCount; c++)
                    {
                        result[r,c] = arr[i];
                        i++;
                    }
                return result;
            }
    
            static void Main(string[] args)
            {
                const int RowCount = 6;
                const int ColCount = 9;
    
                double[,] arr = new double[RowCount,ColCount];
                for (int r = 0; r < RowCount; r++)
                    for (int c = 0; c < ColCount; c++)
                        arr[r,c] = r*c;
    
                ManagedToNative(RowCount, ColCount, Flattened(RowCount, ColCount, arr));
    
                int myRowCount, myColCount;
                NativeToManaged(out myRowCount, out myColCount, null);
                double[] flat = new double[myRowCount * myColCount];
                NativeToManaged(out myRowCount, out myColCount, flat);
                double[,] expanded = Expanded(myRowCount, myColCount, flat);
    
                for (int r = 0; r < RowCount; r++)
                    for (int c = 0; c < ColCount; c++)
                        System.Console.WriteLine(arr[r, c] - expanded[r, c]);
            }
        }
    }
