    class Program
    {
        static void Main(string[] args)
        {
            int maxListLength = 10;
            Stack<int> numbers = new Stack<int>(maxListLength);
            int inputInteger = 0;
            string input = string.Empty;
            while (true)
            {
                Console.WriteLine("What do you want to do?\n\nAdd = 1\nDequeue = 2\nExit = 3\n");
                input = Console.ReadLine();
                if (int.TryParse(input, out int convertedInput))
                {
                    inputInteger = convertedInput;
                }
                else
                {
                    Console.WriteLine("Input must be an integer");
                    continue;
                }
                switch (inputInteger)
                {
                    case 1:
                        Console.WriteLine("You choose to Add");
                        if (numbers.Count != maxListLength)
                        {
                            Console.WriteLine("What value do you want to add?");
                            input = Console.ReadLine();
                            if (int.TryParse(input, out convertedInput))
                            {
                                inputInteger = convertedInput;
                                numbers.Push(inputInteger);
                            }
                            else
                            {
                                Console.WriteLine("Input must be an integer");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("The Queue is full");
                        }
                        break;
                    case 2:
                        Console.WriteLine("You chose to Dequeue");
                        if (numbers.Count > 0)
                        {
                            Console.WriteLine("The dequeue value is: " + numbers.Pop());
                        }
                        else
                        {
                            Console.WriteLine("The Queue is empty");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Exit program\nPress a button to exit");
                        Console.ReadLine();
                        return;
                        break;
                    default:
                        Console.WriteLine("Input must be 1, 2 or 3");
                        continue;
                        break;
                }
            }
        }
    }
