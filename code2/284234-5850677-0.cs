    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Threading;
        
    namespace ConsoleApplication1
    { 
        
        class Program
        {
        
            /// <summary>
            /// Formats the given size to the order of magniture given
            /// Order is 1 for KB, 2 for MB etc up to 8, after that you get exponents for the same notations
            /// </summary>
            /// <param name="size">The total size in bytes</param>
            /// <param name="order">+1 for each 1024 B,M,... 0 for nothing</param>
            /// <param name="unit">Usually you will want B for bytes denotation, but maybe "bit" or "bi" or W for watt</param>
            /// <param name="decimal_places">Number of desired decimal places</param>
            /// <param name="add_space">Separate KB MB etc from the number with a space?</param>
            /// <returns>Formatted size</returns>
            public static string FormatSize(string unit, double size, int order, int decimal_places, bool add_space) {
        
                string[] suffixes = new string[] {"", "K","M","G","T","P","E","Z","Y"};
        
                int exponent = order - 8 > 0 ? order - 8 : 0;
                order -= exponent;
        
                string suffix = suffixes[order];
        
                while (order > 0) {
                    size /= 1024;
                    order--;
                }
        
                string sDecimals = new String('0', decimal_places);
                string sExponent = exponent != 0 ? "E" + exponent : "";
                string dot = decimal_places > 0 ? "." : "";
        
                return size.ToString("#,##0" + dot + sDecimals + sExponent) + (add_space ? " " : "") + suffix + unit;
            }
        
            public static void Main(string[] Args)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        
                string sz;
                sz = FormatSize("B", 1024, 1, 0, false);
                Console.WriteLine(sz);
                sz = FormatSize("B", 1024*1024 + 512, 1, 0, true);
                Console.WriteLine(sz);
                sz = FormatSize("W", 1024 * 1024 + 512, 1, 2, true);
                Console.WriteLine(sz);
                sz = FormatSize("B", 1024 * 1024 + 512, 2, 2, true);
                Console.WriteLine(sz);
                sz = FormatSize("B", 1024 * 1024 * 1024 + 1024 * 1024 * 1024 / 2, 3, 0, false);
                Console.WriteLine(sz);
                sz = FormatSize("bit", 1024 * 1024 * 1024 + 1024 * 1024 * 1024 / 2, 3, 1, false);
                Console.WriteLine(sz);
                sz = FormatSize("B", 1024 * 1024 * 1024 + 1024 * 1024 * 1024 / 2 - 1, 3, 2, false);
                Console.WriteLine(sz);
                sz = FormatSize("Ω", 1024 * 1024 * 1024 + 1024 * 1024 * 1024 / 2 - 1, 3, 1, false);
                Console.WriteLine(sz);
                sz = FormatSize("B", 1024 * 1024 * 1024 + 1024 * 1024 * 1024 / 2 - 10000000, 3, 2, false);
                Console.WriteLine(sz);
                sz = FormatSize("B", 1024 * 1024 * 1024 + 1024 * 1024 * 1024 / 2 - 1, 3, 0, false);
                Console.WriteLine(sz);
                sz = FormatSize("bit", 1208925819614629174706176f, 9, 2, true);
                Console.WriteLine(sz);
            }
        }
    }
