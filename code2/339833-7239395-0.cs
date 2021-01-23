            string[,] newLine = new string[src.Count, 4];
            for (int i = 0; i < newLine.GetUpperBound(0); i++)
            {
                for (int j = 0; j < newLine.GetUpperBound(1); j++)
                {
                    newLine[i, j] = "....";
                }
            }
