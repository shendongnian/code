    // In Library.dll
    using System.Runtime.CompilerServices;
    [assembly:InternalsVisibleTo("Test")]
    public class Library
    {
        public static object Foo()
        {
            return new { ID = 1 };
        }
    }
    // In Test.exe
    using System;
    
    class Test
    {
        static void Main()
        {
            dynamic d = Library.Foo();
            Console.WriteLine(d.ID);
        }
    }
