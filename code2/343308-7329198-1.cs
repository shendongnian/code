    class Program {
     public static void Main()
     {
      int v75 = int.MinValue;
      System.Console.WriteLine("{0:x}", v75 | 0x862D63D3);
      System.Console.WriteLine("{0:x}", (ulong)(long)v75 | 0x862D63D3);
      System.Console.WriteLine("{0:x}", (uint)v75 | 0x862D63D3);
     }
    }
