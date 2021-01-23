    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Tools.ToUpperCase("Behnoud Sherafati"));
        }
    }
    public static class Tools
    {
        public static string ToUpperCase(string str)
        {
            return str.ToUpper();
        }
    }
    }
