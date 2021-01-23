            List<string[]> data = new List<string[]>();
            string readFromReadLine;
            while ((readFromReadLine= sr.ReadLine()) != null)
            {
                data.Add(readFromReadLine.Split(','));
            }
            string[,] lines = new string[data.Count,yourArrayLength];
            //convert array of arrays to multidimensional 
            for (int x=0;x<data.Count;x++)
            {
                for (int y = 0; y < yourArrayLength; y++)
                {
                    lines[x, y] = data[x][y];
                }
            }
