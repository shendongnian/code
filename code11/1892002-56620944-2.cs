    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                bool bValidNumEntered;
                int valueFromUser;
    
                //Method 1
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
    
                //Method 2
    
                int[] lucky2 = new int[5];
    
                for (int i = 0; i < 5; i++)
                {
                    bValidNumEntered = false;
    
                    do
                    {
                        Console.WriteLine("Please enter a number");
    
                        if (int.TryParse(Console.ReadLine(), out valueFromUser))
                        {
                            if ((Array.IndexOf(lucky2, valueFromUser) == -1) && (valueFromUser > 0 && valueFromUser < 48))
                            {
                                lucky2[i] = valueFromUser; bValidNumEntered = true;
                            }
                        }
    
                    } while (!bValidNumEntered);
                }
    
                Console.WriteLine("Your chosen numbers are: {0} ,{1}, {2}, {3}, {4} ", lucky2[0], lucky2[1], lucky2[2], lucky2[3], lucky2[4]); Console.ReadKey();
            }
        }
    }
