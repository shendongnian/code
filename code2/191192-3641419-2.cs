    using System;
    using System.Runtime.InteropServices;
    namespace Test
    {
     class Program
     {
      [StructLayout(LayoutKind.Explicit, Size=4)]
      struct UnionInt32Value
      {
       [FieldOffset(0)] public byte byte1;
       [FieldOffset(1)] public byte byte2;
       [FieldOffset(2)] public byte byte3;
       [FieldOffset(3)] public byte byte4;
       [FieldOffset(0)] public Int32 iVal;
      }
      public static void Main(string[] args)
      {
       UnionInt32Value v = new UnionInt32Value();
       v.byte1=1;
       v.byte2=0;
       v.byte3=0;
       v.byte4=0;
       Console.WriteLine("this is one " + v.iVal);
    
       v.byte1=0xff;
       v.byte2=0xff;
       v.byte3=0xff;
       v.byte4=0xff;
       Console.WriteLine("this is minus one " + v.iVal);
       
       Console.Write("Press any key to continue . . . ");
       Console.ReadKey(true);
      }
     }
    }
