    using System.Runtime.CompilerServices;
    ...
        static void Main(string[] args) {
            Test();
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        static void Test() {
            Console.WriteLine(new ClassLibrary1.Class1().TestString());
            Console.WriteLine();
            Console.WriteLine("Done...");
            Console.ReadLine();
        }
