    static void Main(string[] args)
            {
                while (true)
                {
                    Console.Write("Enter a number between 1 and 100: ");
                    int Number = Convert.ToInt32(Console.ReadLine());
                    if (Number < 0 || Number > 100)
                        Console.WriteLine("Sorry. Try again.");
                    else
                    {
                        int sum = 0;
                        for (int i = 1; i <= Number; i++)
                        {
                            sum = sum + i;
                        }
    
                        Console.WriteLine("Sum of values: " + sum);
                    }
                }
            }
