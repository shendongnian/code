    using System;
    using System.Globalization;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                CultureInfo ci = new CultureInfo("en-US", true);            
                Thread.CurrentThread.CurrentCulture = ci;
                Console.WriteLine("Input next value:");
                string input = Console.ReadLine();
                
                while (input != "e")
                {
                    double dblInput = double.Parse(input);
                    CultureInfo ci2 = new CultureInfo("fa-IR", true);
                    ci2.NumberFormat.DigitSubstitution = DigitShapes.NativeNational;
                    ci2.NumberFormat.NumberDecimalSeparator = "/";
                    Thread.CurrentThread.CurrentCulture = ci2;
                    
                    Console.WriteLine(dblInput);
                    Console.WriteLine("Input next value:");
                    input = Console.ReadLine();
                }
            }
        }
    }
