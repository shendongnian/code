            int numPages = 1;
            int maxLine = 20;
            int currentLine = 0;
            while (true)
            {
                Console.WriteLine(String.Format($"Page {numPages}; Line {currentLine}"));
                currentLine++;
                if (currentLine > maxLine)
                {
                    Console.WriteLine("Press ENTER to continue, 'x' to stop");
                    string answer = Console.ReadLine();
                    if (answer.Length > 0 && (answer[0] == 'x' || answer[0] == 'X'))
                    {
                        break;
                    }
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    currentLine = 0;
                    numPages++;
                }
            }
            Console.ReadLine();
