        public void DrawGrid()
        {
            Console.WriteLine();
            for (int y = 0; y < shipGrid.GetLength(1); y++)
            {
                string currentLine = $"{y + 1} | ";
                for (int x = 0; x < shipGrid.GetLength(0); x++)
                {
                    char shot = shotGrid[x, y];
                    currentLine += shot + "~ ";
                }
                
                Console.WriteLine(currentLine);
            }
            Console.WriteLine();
        }
