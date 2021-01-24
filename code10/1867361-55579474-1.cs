    public void DrawTree(string directoryPath)
            {
                if (string.IsNullOrWhiteSpace(directoryPath))
                {
                    throw new ArgumentException(
                        "Provided directory path is null, emtpy " +
                        "or consists of only whitespace characters.",
                        nameof(directoryPath));
                }
    
                DrawTree(new DirectoryInfo(directoryPath));
                //remember current position because we need to return position to it
                int currentCursorPositionTop = Console.CursorTop;
                //set position to the last row
                Console.SetCursorPosition(0, Console.CursorTop-1);
                //change the first charachter
                Console.Write("└");
                //return cursor position to the previous one so our "Press any key to continue" can apear below our list.
                Console.SetCursorPosition(0, currentCursorPositionTop);
            }
