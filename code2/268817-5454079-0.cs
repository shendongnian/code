        using System;
    using System.Collections.Generic;
    using System.Linq;
    public class TotalPurchase
    {
        public static void Main()
        {
            List<double> total4 = new List<double>();
            List<double> total5 = new List<double>();
            List<double> total6 = new List<double>();
            int myint = -1;
            while (myint != 0)
            {
                string group;
                Console.WriteLine("Please enter group number (4, 5, or 6)");
                Console.WriteLine("(0 to quit): ");
                group = Console.ReadLine();
                myint = Int32.Parse(group);
                switch (myint)
                {
                    case 0:
                        break;
                    case 4:
                        double donation4;
                        string inputString4;
                        Console.WriteLine("Please enter the amount of the contribution: ");
                        inputString4 = Console.ReadLine();
                        donation4 = Convert.ToDouble(inputString4);
                        total4.Add(donation4);
                        break;
                    case 5:
                        double donation5;
                        string inputString5;
                        Console.WriteLine("Please enter the amount of the contribution: ");
                        inputString5 = Console.ReadLine();
                        donation5 = Convert.ToDouble(inputString5);
                        total5.Add(donation5);
                        break;
                    case 6:
                        double donation6;
                        string inputString6;
                        Console.WriteLine("Please enter the amount of the contribution: ");
                        inputString6 = Console.ReadLine();
                        donation6 = Convert.ToDouble(inputString6);
                        total6.Add(donation6);
                        break;
                    default:
                        Console.WriteLine("Incorrect grade number.", myint);
                        break;
                }
            }
            if(total4.Count > 0)
                Console.WriteLine("Grade 4 total is {0}; Average {1}", total4.Sum().ToString("C"), total4.Average().ToString("C"));
            if(total5.Count >0)
                Console.WriteLine("Grade 5 total is {0}; Average {1}", total5.Sum().ToString("C"), total5.Average().ToString("C"));
            if (total6.Count > 0)
                Console.WriteLine("Grade 6 total is {0}; Average {1}", total6.Sum().ToString("C"), total6.Average().ToString("C"));
        }
    }
