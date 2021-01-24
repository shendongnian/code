            string csvBoard = "0,1,0\n2,0,1\n0,0,1";
            // This splits the csv text into rows and each is a string
            string[] rows = csvBoard.Split('\n');
            // Need to alocate a array of the same size as your csv table 
            int[,] table = new int[3, 3];
            // It will go over each row
            for (int i = 0; i < rows.Length; i++)
            {
                // This will split the row on , and you will get string of columns
                string[] columns = rows[i].Split(',');
                for (int j = 0; j < columns.Length; j++)
                {
                    //all is left is to set the value to it's location since the column contains string need to parse the values to integers
                    table[i, j] = int.Parse(columns[j]);
                }
            }
            // For jagged array and some linq
            var tableJagged = csvBoard.Split('\n')
                                      .Select(row => row.Split(',')
                                                     .Select(column => int.Parse(column))
                                                     .ToArray())
                                       .ToArray();
