using System;
using CSScriptLibrary;
namespace EmbedCS
{
    public class Program
    {
        public static int[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public static Random rnd = new Random();
        static void Main(string[] args)
        {
            ExecuteTest();
            Console.Read();
        }
        private static void ExecuteTest()
        {
            bool result;
            var scriptFunction = CSScript.CreateFunc<bool>(@"
                bool func() {
                    int a = EmbedCS.Program.rnd.Next(10);
                    int b = EmbedCS.Program.rnd.Next(10);
                    return EmbedCS.Program.values[a] > EmbedCS.Program.values[b];
                }
            ");
            result = (bool)scriptFunction();
            Console.Read();
        }
    }
}
Remeber that, in C# everything is so implicit. 
your `func()` is not a member of `Program`. So they can't recognize fields inside the `Program`.
Some dynamic languages have binding context(such as ruby's `binding`) in language level, so libraries can do black magic stuffs. but not in C#.
