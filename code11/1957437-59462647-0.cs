    [DllImport("CUDALib.dll", CallingConvention = CallingConvention.Cdecl)]
    static extern int Add(int[,] a, int m, int n);
    static void PassArray(int[,] A)
    {
        int m = A.GetLength(0);
        int n = A.GetLength(1);
        int ans = Add(A, m, n);
    }
