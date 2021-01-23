    class Program
    {
        delegate double MyCallback(double x, double y);
        [DllImport("Calc.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double Calc(double x, double y, [MarshalAs(UnmanagedType.FunctionPtr)]MyCallback func);
        static void Main(string[] args)
        {
            double z = Calc(1, 2, (x, y) => 45);
        }
    }
