    foreach (string[,] array in cross)
    {
       for (int i = 0; i < array.GetLength(0); i++)
       {
           for (int j = 0; j < array.GetLength(1); j++)
           {
               string item = array[i, j];
               // do something with item
           }
       }
    }
