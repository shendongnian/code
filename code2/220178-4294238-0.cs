    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
        class Program
        {
            static void Main(string[] args)
            {
                var str = Console.ReadLine();
    
                Regex regex = new Regex(@"\s+");
                var intArrary = regex.Split(str).Select(x => int.Parse(x));
            }
        }
