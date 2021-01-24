    using System;
    
    namespace BeautifyConsoleSO
    {
        class Program
        {
            static void Main(string[] args)
            {
                char inputPrefix = '>';
                bool flag = false;
                string historyInput = string.Empty;
                string currentInput = string.Empty;
    
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
    
                    Console.Clear();
                    Console.WriteLine(historyInput);
                    Console.Write("{0}{1}", inputPrefix, currentInput);
                       
                }
    
                Console.ReadLine();
            }
    
        }
    }
