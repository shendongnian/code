    int[,] array1 = new int[6, 6]
    {
        {10, 20, 10, 20, 21, 99 },
        {2, 27, 5, 45, 20, 13 },
        {17, 20, 20, 33, 33, 20 },
        {21, 35, 15, 54, 20, 37 },
        {31, 101, 25, 55, 26, 66 },
        {45, 20, 44, 12, 55, 98 }
    };
    
    int Length = array1.GetLength(0);
    int Height = array1.GetLength(1);
    List<int> CalculateRow = new List<int>(){0,0,0,0,0};
    
    for ( int i = 0; i < Length; i++ )
    {
      for ( int j = 0; j < Height; j++ )
      {
        CalculateRow[i] = CalculateRow + array1[i, j];
      }
      Console.Write("Enter the number of the Row you would like to see the sum of: ");
      int h = Convert.ToInt32(Console.ReadLine());
      if ( h > 5 )
      {
        Console.Write(-1);
      }
      else
        Console.WriteLine("The sum of Row {0} is {1} ", h, CalculateRow[h]);
    }
