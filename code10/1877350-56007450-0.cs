    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
            while (true)
                {
                Console.WriteLine("Please enter number from range 0-19 ");
                string numberInput = Console.ReadLine();
                int IntNumberInput = 0;
                try {
                    IntNumberInput = System.Convert.ToInt32(numberInput);
                    if (IntNumberInput >= 0 && IntNumberInput <= 19)
                    {
                        int CalculationResult = 20 - IntNumberInput;
                        Console.WriteLine("You enter number from range 0-19 , Result was " + CalculationResult.ToString());
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
                catch (Exception ex) { Console.WriteLine("Sorry that is not allowed , Please enter number from range 0-19"); }
                }
                        
        }
 
