     public static string[,] ToMultiDimensionalArray(this List<string[]> dt)
            {
               if (dt.Count == 0 )
                   throw new ArgumentException("Input arg has no elemets");
               int col = dt[0].Count();
                string[,] arr = new string[dt.Count, col];
                int r = 0;
                foreach (string[] dr in dt)
                {
                    for (int c = 0; c < col; c++)
                    {
                        arr[r, c] = dr[c];
                    }
                    r++;
                }
                return arr;
            }
