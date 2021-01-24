    using System;
    using System.Linq;
    
    namespace BeautifyConsoleSO
    {
        class Program
        {
            static void Main(string[] args)
            {
                char inputPrefix = '>';
                bool flag = false;
                int clearConsoleRefreshSpeed = 100;
                int clearConsoleTick = 0;
                string historyInput = string.Empty;
                string currentInput = string.Empty;
    
                string fix = string.Concat(Enumerable.Repeat(Environment.NewLine, Console.WindowHeight));
                Console.WriteLine(fix);
    
                historyInput += "Hello World!";
    
                Console.WriteLine(historyInput);
                Console.Write(inputPrefix);
                
                while(flag != true)
                {
                    ConsoleKeyInfo input = Console.ReadKey();
    
                    switch(input.Key)
                    {
                        case ConsoleKey.Spacebar:
                            currentInput += ' ';
                            break;
                        case ConsoleKey.Enter:
                            historyInput += Environment.NewLine;
                            historyInput += currentInput;
                            currentInput = string.Empty;
                            break;
                        case ConsoleKey.Backspace:
                            if(currentInput.Length > 0)
                            {
                                if (!currentInput[currentInput.Length - 1].Equals(' '))
                                {
                                    currentInput = currentInput.Remove(currentInput.Length - 1);
                                }
                                else
                                {
                                    currentInput = currentInput.Remove(currentInput.Length - 2);
                                }
                            }
                            break;
                        default:
                            currentInput += input.KeyChar;
                            break;
                    }
    
                    // attempt to fix flickering associated with Console.Clear()
                    Console.WriteLine(fix);
    
                    Console.WriteLine(historyInput);
                    Console.Write("{0}{1}", clearConsoleTick + " " +  inputPrefix, currentInput);
    
                    clearConsoleTick++;
    
                    if(clearConsoleTick % clearConsoleRefreshSpeed == 0)
                    {
                        Console.Clear();
                        Console.WriteLine(fix);
                    }
                }
    
                Console.ReadLine();
            }
    
        }
    }
