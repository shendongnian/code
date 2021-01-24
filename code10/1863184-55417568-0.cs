    static void Main(string[] args)
            {
                string inputValue = Console.ReadLine();
    
                bool isValid = true;
                foreach (char val in inputValue)
                {
                    if (inputValue.First()==val && char.IsUpper(val))
                    {
                      //do nothing.
                    }
                    else if(char.IsLower(val))
                    {
                        // do nothing.
                    }
                    else
                    {
                        isValid = false;
                        Console.WriteLine("Invalid input string");
                        Console.ReadLine();
                        break;
                    }
                }
    
                if (isValid)
                {
                    Console.WriteLine("Valid input string");
                    Console.ReadLine();
                }
    
            }
