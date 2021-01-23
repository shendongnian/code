           string[,] input = new string[5, 3];
           string[] output = new string[15];
           for (int i = 0; i < input.GetUpperBound(0); i++)
           {
               for (int j = 0; j < input.GetUpperBound(1); j++)
               {
                   output[j * input.GetUpperBound(j) + i] = input[i, j];
               }
           }
