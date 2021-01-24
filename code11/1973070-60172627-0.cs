    public static void Main()
            {
                Console.WriteLine("question");
                bool tryAgain;
                do
                {
                    tryAgain = true;
                    var key = Console.ReadKey();
                    switch (key.KeyChar)
                    {
                        case 'a':
                        case 'b':
                            Console.WriteLine();
                            Console.WriteLine("Incorrect");
                            tryAgain = false;
                            break;
                        case 'c':
                            Console.WriteLine();
                            Console.WriteLine("Correct");
                            tryAgain = false;
                            break;
                        default:
                            Console.Write("\b \b");
                            break;
                    }
                } while (tryAgain);
            }
