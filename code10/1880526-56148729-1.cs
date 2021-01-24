      public static void Main(string[] args)
            {
                string txt = "this is a an example string";
                string wordToFind = "example string";
                bool phraseFound = false;
                var splittedTxt = txt.Split(' ');
                var wordToFindList = wordToFind.Split(' ');
                foreach (var item in splittedTxt)
                {
                    if (wordToFindList.Any(item.Contains))
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                        phraseFound = true;
                    }
                    Console.Write(item);
                    if (phraseFound) // reset color
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        phraseFound = false;
                    }
                    Console.Write(" ");
                }
    
    
                Console.ReadLine();
            }
 
           
