lang-cs
using System;
using Splat;
namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main()
        {
            // Register
            Locator.CurrentMutable.Register(() => new Bar(), typeof(IFoo), "giveMeBar");
            Locator.CurrentMutable.Register(() => new Baz(), typeof(IFoo), "giveMeBaz");
            // Resolve
            var bar = Locator.Current.GetService<IFoo>("giveMeBar");
            var baz = Locator.Current.GetService<IFoo>("giveMeBaz");
            // Which types did we get?
            Console.WriteLine(bar);
            Console.WriteLine(baz);
            Console.ReadLine();
            // Outputs:
            // ConsoleApp1.Bar
            // ConsoleApp1.Baz
        }        
    }
    internal interface IFoo { }
    internal class Bar : IFoo { }
    internal class Baz : IFoo { }
}
