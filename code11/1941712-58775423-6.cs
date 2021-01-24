        public void DrawGrid()
        {
            Console.WriteLine();
            for (int y = 0; y < shotGrid.GetLength(1); y++)
            {
                string currentLine = $"{y + 1} | ";
                for (int x = 0; x < shotGrid.GetLength(0); x++)
                {
                    char shot = shotGrid[x, y];
                    currentLine += shot.ToString();
                }
                
                Console.WriteLine(currentLine);
            }
            Console.WriteLine();
        }
