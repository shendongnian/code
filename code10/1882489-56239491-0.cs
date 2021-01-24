    if (decisionForWholeWords == true && decisionForSpelling == false)
    {
			int index = 0;
            foreach (var item in splittedTxt)
            {
                //do what you want the index.
                if (wordToFind.ToLower() == item.ToLower())
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    wordFound = true;
                }
                Console.Write(item);
                if (wordFound) // reset color
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    wordFound = false;
                }
                Console.Write(" ");
                
                index += item.Length;
                index += 1; //for the space
            }
        }
