    using System;
    using System.Runtime.InteropServices;
    class uDMXTest
    {
      [DllImport("uDMX.dll")]
      public static extern bool Configure();
    
      public static void Main()
      {
        bool result;
        result = Configure();
        Console.WriteLine(result);
      }
    }
