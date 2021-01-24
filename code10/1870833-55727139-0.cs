        public void PrintCard()
        {
            if (_value == 1)
            {
                _printString =
                    " V         " +
                    "           " +
                    "           " +
                    "     S     " +
                    "           " +
                    "           " +
                    "         V " ;
                PrintMethod();
            }
            if (_value == 2)
            {
                _printString =
                    " V         " +
                    "     S     " +
                    "           " +
                    "           " +
                    "           " +
                    "     S     " +
                    "         V ";
                PrintMethod();
            }
            if (_value == 3)
            {
                _printString =
                    " V         " +
                    "     S     " +
                    "           " +
                    "     S     " +
                    "           " +
                    "     S     " +
                    "         V ";
                PrintMethod();
            }
            if (_value == 4)
            {
                _printString =
                    " V         " +
                    "   S   S   " +
                    "           " +
                    "           " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                PrintMethod();
            }
            if (_value == 5)
            {
                _printString =
                    " V         " +
                    "   S   S   " +
                    "           " +
                    "     S     " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                PrintMethod();
            }
            if (_value == 6)
            {
                _printString =
                    " V         " +
                    "   S   S   " +
                    "           " +
                    "   S   S   " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                PrintMethod();
            }
            if (_value == 7)
            {
                _printString =
                    " V         " +
                    "   S   S   " +
                    "     S     " +
                    "   S   S   " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                PrintMethod();
            }
            if (_value == 8)
            {
                _printString =
                    " V         " +
                    "   S   S   " +
                    "     S     " +
                    "   S   S   " +
                    "     S     " +
                    "   S   S   " +
                    "         V ";
                PrintMethod();
            }
            if (_value == 9)
            {
                _printString =
                    " V         " +
                    "   S S S   " +
                    "           " +
                    "   S S S   " +
                    "           " +
                    "   S S S   " +
                    "         V ";
                PrintMethod();
            }
            if (_value == 10 || _value == 11 || _value == 12 || _value == 13)
            {
                _printString =
                    " V         " +
                    "    S S    " +
                    "     S     " +
                    "  S S S S  " +
                    "     S     " +
                    "    S S    " +
                    "         V ";
                PrintMethod();
            }
        }
        private void PrintMethod()
        {
            bool hasWrittenFirstNumber = false;
            switch (_suit)
            {
                case "Hearts":
                case "Diamonds":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "Clubs":
                case "Spades":
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }
            for (int i = 0; i < _printString.Length; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if (i % 11 == 0 && i != 0)
                {
                    Console.CursorLeft -= 11;
                    Console.CursorTop += 1;
                }
                if (_printString[i] == 'S')
                {
                    switch (_suit)
                    {
                        case "Hearts":
                            Console.Write('♥');
                            break;
                        case "Clubs":
                            Console.Write("♣");
                            break;
                        case "Diamonds":
                            Console.Write("♦");
                            break;
                        case "Spades":
                            Console.Write("♠");
                            break;
                    }
                    continue;
                }
                else if (_printString[i] == 'V')
                {
                    if (_value == 10)
                    {
                        if (hasWrittenFirstNumber == false)
                        {
                            Console.Write(10);
                            hasWrittenFirstNumber = true;
                            i++;
                        }
                        else
                        {
                            Console.CursorLeft--;
                            Console.Write(10);
                        }
                        continue;
                    }
                    else if (_value == 11)
                    {
                        Console.Write("J");
                    }
                    else if (_value == 12)
                    {
                        Console.Write("Q");
                    }
                    else if (_value == 13)
                    {
                        Console.Write("K");
                    }
                    else if (_value == 1)
                    {
                        Console.Write("A");
                    }
                    else
                    {
                        Console.Write(_value);
                    }
                }
                else
                {
                    Console.Write(_printString[i]);
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
