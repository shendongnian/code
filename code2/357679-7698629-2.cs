            // assuming the numbers are in perfect 2D format in textBox (only 1 newline separates the lines, only 1 space separates numbers in each line and all lines have the same amount of numbers)
            string textWithNumbers = textBox.Text;
            // first put all lines into an string array
            string[] allLines = textWithNumbers.Split(new string[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            // calculate 2D array's dimension lengths, and initialize the 2Darray
            int rowCount = allLines.Length;
            int columnCount = ((allLines[0].Length + 1) / 2);
            int[,] twoDArray = new int[rowCount, columnCount];
            // we then iterate through the 2D array
            for (int row = 0; row < rowCount; row++)
            {
                // parse each number from string format to integer format & assign it to the corresponding location in our 2D array
                string[] line = allLines[row].Split(' ');
                for (int column = 0; column < columnCount; column++)
                {
                    twoDArray[row, column] = int.Parse(line[column]);
                }
            }
