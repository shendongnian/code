            int[,] arrNew = arr.Clone() as int[,]; //creates a copy of arr
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    if (arr[i, j] == 1)
                    {
                        if (i > 0) //bounds checking
                        {
                            arrNew[i - 1, j] = 1;
                        }
                        if (i < m - 1) //bounds checking
                        {
                            arrNew[i + 1, j] = 1;
                        }
                        if (j > 0) //bounds checking
                        {
                            arrNew[i, j - 1] = 1;
                        }
                        if (j < n - 1) //bounds checking
                        {
                            arrNew[i, j + 1] = 1;
                        }
                    }
                }
            }
