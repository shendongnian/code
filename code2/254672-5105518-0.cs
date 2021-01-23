    [DllImport("DLL.dll", CallingConvention=CallingConvention.StdCall,
        CharSet=CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool Get_Matrix(StringBuilder Matrix);
    static void Main(string[] args)
    {
        StringBuilder Matrix = new StringBuilder(200);
        Get_Matrix(Matrix);
    }
