    public static void Main()
            {
                Console.WriteLine("question");
                bool tryAgain;
                bool enterPressed;
                char input = ' ';
                do
                {
                    enterPressed = false;
                    do
                    {
                        tryAgain = true;
                        var key = Console.ReadKey();
                        switch (key.KeyChar)
                        {
                            case 'a':
                            case 'b':
                            case 'c':
                                input = key.KeyChar;
                                tryAgain = false;
                                break;
                            default:
                                Console.Write("\b \b");//Delete last char
                                break;
                        }
                    } while (tryAgain);
                    var confirmkey = Console.ReadKey();
                    if (confirmkey.Key == ConsoleKey.Enter)
                    {
                        enterPressed = true;
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write("\b \b"); //Delete last char
                    }
                } while (!enterPressed);
                switch (input)
                {
                    case 'a':
                    case 'b':
                        Console.WriteLine("incorrect");
                        break;
                    case 'c':
                        Console.WriteLine("correct");
                        break;
                }
            }
