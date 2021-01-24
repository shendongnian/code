    using System;
    using System.Collections.Generic;
    
    namespace queue
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                int max = 10;
                var items = new List<int>();
                int b; //user input
                int nbElements = 0;
    
                do
                {
                    Console.WriteLine
                         ("What do you want to do?");
    
                    Console.WriteLine();
    
                    Console.WriteLine("Add = 1");
                    Console.WriteLine("Dequeue = 2");
                    Console.WriteLine("Exit = 3");
    
                    Console.WriteLine();
    
                    b = int.Parse(Console.ReadLine());
    
                    Console.WriteLine();
    
                    if (b == 1)
                    {
                        Console.WriteLine("You choose to Add");
    
                        if (nbElements != max)
                        {
                            Console.WriteLine("What value do you want to add?");
                            int v; //value
    
                            v = int.Parse(Console.ReadLine());
                            items.Add(v);
                            nbElements++;
    
                        }
    
                        else
                        {
                            Console.WriteLine("The Queue is full");
                            foreach (var item in items)
                            {
                                Console.WriteLine(item);
                            }
                        }
    
                    }
    
                    else if (b == 2)
    
                    {
                        Console.WriteLine();
                        Console.WriteLine("You chose to Dequeue");
    
                        if (nbElements != 0)
                        {
    
                            Console.WriteLine("The dequeue value is:" + items[0]);
                            items.RemoveAt(0);
                            nbElements--;
                        }
    
                        else
    
                            Console.WriteLine(" Queue is empty");
                    }
    
                    else if (b == 3)
                    {
                        Console.WriteLine("Exit program");
                        Console.WriteLine();
                        Console.WriteLine("Press Enter to exit");
                        Console.ReadLine();
                        Environment.Exit(0);
    
                    }
    
                    else
    
                    {
                        Console.WriteLine("Enter a valid option");
                        Console.WriteLine();
                    }
    
                } while (b != 'X');
    
            }
        }
    }
