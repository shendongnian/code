    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;     // DLL support
    namespace ConsoleApplication1
    {
      class Program
      {
        [DllImport("dodll.dll",
    	       CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        private static extern string dodll(int a, int b,
    				       [MarshalAs(UnmanagedType.LPArray)] float[] nums,
    				       [MarshalAs(UnmanagedType.LPStr)] string strA,
    				       [MarshalAs(UnmanagedType.LPStr)] string strB);
    static void Main(string[] args)
    {
      int x = 2; int y = 3;
      float[] numbers = new float[3]{12.3F, 45.6F, 78.9F};
      float[] simargs = new float[20];
      string strvarA = "Test string A";
      string strvarB = "Test another string";
      string answer = dodll(x, y, numbers, strvarA, strvarB);
      Console.WriteLine("hello world " + answer);
      Console.WriteLine("another hello world" + x);
      Console.WriteLine("End of sim");
    }
