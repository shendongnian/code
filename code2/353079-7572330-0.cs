    using System;
    using System.Text.RegularExpressions;
    namespace SimpleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                Regex theRegex = new Regex(@">Total:<.+?<strong>(.+?)</strong>");
                string str = @"<td colspan=""2""><div align=""right"" class=""txtnormal"">Total:</div></td>" +
                         @"<td class=""txtnormal""><div align=""right""><strong>10.00</strong></div></td>" +
                         @"<td colspan=""2"">&nbsp;</td>";
                if (theRegex.Match(str).Success)
                {
                    Console.WriteLine("Found Total of " + theRegex.Match(str).Result("$1"));
                }
                else
                {
                    Console.WriteLine("Not found");
                }
                Console.ReadLine();
            }
        }
    }
