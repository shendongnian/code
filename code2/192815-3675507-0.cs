    class Program
    {
        static void Main(string[] args)
        {
            System.Console.ReadLine();
        }
        static void EndlessWhile()
        {
            while (true)
            {
                Console.WriteLine("Hello");
            }
        }
        static void EndlessFor()
        {
            for (; ; )
            {
                Console.WriteLine("Hello");
            }
        }
    }
    // IL of both the functions are mentioned below.
    .method private hidebysig static void  EndlessWhile() cil managed
    {
      // Code size       20 (0x14)
      .maxstack  1
      .locals init ([0] bool CS$4$0000)
      IL_0000:  nop
      IL_0001:  br.s       IL_0010
      IL_0003:  nop
      IL_0004:  ldstr      "Hello"
      IL_0009:  call       void [mscorlib]System.Console::WriteLine(string)
      IL_000e:  nop
      IL_000f:  nop
      IL_0010:  ldc.i4.1
      IL_0011:  stloc.0
      IL_0012:  br.s       IL_0003
    } // end of method Program::EndlessWhile
    .method private hidebysig static void  EndlessFor() cil managed
    {
      // Code size       20 (0x14)
      .maxstack  1
      .locals init ([0] bool CS$4$0000)
      IL_0000:  nop
      IL_0001:  br.s       IL_0010
      IL_0003:  nop
      IL_0004:  ldstr      "Hello"
      IL_0009:  call       void [mscorlib]System.Console::WriteLine(string)
      IL_000e:  nop
      IL_000f:  nop
      IL_0010:  ldc.i4.1
      IL_0011:  stloc.0
      IL_0012:  br.s       IL_0003
    } // end of method Program::EndlessFor
