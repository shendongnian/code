    namespace HighSpeedMathTest
    {
        using System.Runtime.InteropServices;
        class Program
        {
            [DllImport("HighSpeedMath.dll", EntryPoint="math_add", CallingConvention=CallingConvention.StdCall)]
            static extern int Add(int a, int b);
            static void Main(string[] args)
            {
                int result = Add(27, 28);
            }
        }
    }
