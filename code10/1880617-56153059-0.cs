using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace learncsharp
{
    class Program
    {
        static int Value(ref int x)
       {
           x = 100;
           return x;
       }
        public static void Main()
        {
            int z = 10;
            Value(ref z);
            Console.Read();
        }
    }
 }
