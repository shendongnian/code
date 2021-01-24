    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                bool bValidNumEntered;
                int valueFromUser;
    
                List<int> lucky = new List<int>();
    
                for (int i = 0; i < 5; i++)
                {
                    bValidNumEntered = false;
    
                    do
                    {
                        Console.WriteLine("Please enter a number");
    
                        if (int.TryParse(Console.ReadLine(), out valueFromUser))
                        {
                            if (!lucky.Contains(valueFromUser) && (valueFromUser > 0 && valueFromUser < 48))
                            {
                                lucky.Add(valueFromUser); bValidNumEntered = true;
                            }
                        }
    
                    } while (!bValidNumEntered);
                }
    
                Console.WriteLine($"{lucky[0]}, {lucky[1]}, {lucky[2]}, {lucky[3]}, {lucky[4]}"); Console.ReadKey();
            }
        }
    }
