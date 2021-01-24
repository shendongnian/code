    for (int xIndex = 0; xIndex < arr.GetLength(0); xIndex++)
    {
      for (int yLoop = 0; yLoop < arr.GetLength(1); yLoop++)
       {
        if(arr[xIndex, yLoop]==0)
        {
           Console.Write(" ");
        }
       }
        Console.WriteLine();
    }
