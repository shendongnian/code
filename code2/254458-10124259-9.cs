    unsafe class Program
    { 
        static void Main(string[] args)
        {
            double[,] A = new double[10, 10];
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    A[i, j] = 10 * i + j + 1;
                }
            }
            // A has { { 1 ,2 .. 10}, { 11, 12 .. 20}, .. { .. 99, 100} }
            double[] B = new double[10 * 10];
            if (A.Length == B.Length)
            {
                fixed (double* pA = A, pB = B)
                {
                    for(int i = 0; i < B.Length; i++)
                    {
                        pB[i] = pA[i];
                    }
                }
                // B has {1, 2, 3, 4 .. 100}
            }
        }
    }
