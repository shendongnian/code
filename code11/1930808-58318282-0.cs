    static void Main(string[] args)
            {
                int lenght = int.Parse(Console.ReadLine());
                int width = int.Parse(Console.ReadLine());
    
                int cakeSize = lenght * width;
    
                while (cakeSize > 0)
                {
                    string taken = Console.ReadLine();
                    if (taken == "STOP") 
    
                    {
                        Console.WriteLine($"{cakeSize} pieces are left.");
    
                        break;
                    }
                    cakeSize = cakeSize - int.Parse(taken); 
                }
                Console.WriteLine($"No more cake left! You need {Math.Abs(cakeSize)} pieces more.");
                Console.ReadLine();
            }
