            public static void Main(string[] args)
            {
                string txt = "this is  an example string";
                string wordToFind = "example";
                bool wordFound = false;
                var splittedTxt = txt.Split(' ');
                foreach (var item in splittedTxt)
                {
                    if(wordToFind == item)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                        wordFound = true;
                    }
                    Console.Write(item);
                    if (wordFound) // reset color
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        wordFound = false;
                    }
                    Console.Write(" ");
                }   
    
                Console.ReadLine();
            }
