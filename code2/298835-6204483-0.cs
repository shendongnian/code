        static int[,] Combine(params int[][] arrays)
        {
            int[] pointers = new int[arrays.Length];
            int total = arrays.Aggregate(1, (m, array) => m * array.Length);
            int[,] result = new int[total, arrays.Length];
            for (int i = 0; i < arrays.Length; i++)
                result[0, i] = arrays[i][0];
            for (int y = 1; y < total; y++)
                for (int x = arrays.Length - 1; x >= 0; x--)
                {
                    ++pointers[x];
                    for (int i = x; i >= 0; i-- )
                        if (pointers[i] >= arrays[i].Length)
                        {
                            pointers[i] = 0;
                            if (i>0)
                                pointers[i - 1]++;
                        }
                    result[y, x] = arrays[x][pointers[x]];
                }
            return result;
        }
