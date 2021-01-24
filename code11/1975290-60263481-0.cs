      using System;
      using System.Collections.Generic;
      using System.Linq;
      namespace Print
     {
       class Program
       {
        static void Main(string[] args)
        {
            int y = 0;
            string firstInput = Console.ReadLine();
            List<string> strArray = new List<string>();
            int multiplication = 1;
            strArray.Add(firstInput);
            if (firstInput == "x")
            {
                Console.WriteLine(multiplication);
            }
            else
            {
                while (y == 0)
                {
                    multiplication = 1;
                    for (int i = 0; i < strArray.Count; i++)
                    {
                        if (strArray[i] != "x")
                        {
                            int number = Convert.ToInt32(strArray[i]);
                            multiplication *= number;
                            firstInput = Console.ReadLine();
                            strArray.Add(firstInput);
                        }
                        else
                        {
                            y = 1;
                        }
                    }
                }
            }
            Console.WriteLine(multiplication);
        }
    }
     }
