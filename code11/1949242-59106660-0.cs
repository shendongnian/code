using System;
using System.Linq;
namespace RemoveStringFromArray
{
    class Program
    {
        public static int[] RemoveString(object[] a)
        {
            return (from e in a
                    where !(e is string)
                    select (int) e).ToArray();
        }
        static void Main(string[] args)
        {
            object[] a = new object[5];
            a[0] = "Start";
            a[1] = 1;
            a[2] = "Midle";
            a[3] = 10;
            a[4] = "End";
            foreach (var e in a)
            {
                Console.WriteLine("Element {0}", e);
            }
            var i = RemoveString(a);
            Console.WriteLine("After removing strings");
            foreach (var e in i)
            {
                Console.WriteLine("Element {0}", e);
            }
        }
    }
}
This gives the output:
Element Start
Element 1
Element Midle
Element 10
Element End
After removing strings
Element 1
Element 10
Hope it helps.
