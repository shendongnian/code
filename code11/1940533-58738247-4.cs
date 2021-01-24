    int[,] matrix = new int[6, 6]
    {
    {10, 20, 10, 20, 21, 99 },
    {2, 27, 5, 45, 20, 13 },
    {17, 20, 20, 33, 33, 20 },
    {21, 35, 15, 54, 20, 37 },
    {31, 101, 25, 55, 26, 66 },
    {45, 20, 44, 12, 55, 98 }
    };
    int rowsCount = matrix.GetLength(0);
    int columnsCount = matrix.GetLength(1);
    int rowSum = 0;
    Console.Write("Enter the number of the Row you would like to see the sum of: ");
    if ( !int.TryParse(Console.ReadLine(), out var rowIndex)
      || rowIndex < 0 
      || rowIndex > rowsCount )
    {
      Console.Write(-1);
    }
    else
    {
      for ( int columnIndex = 0; columnIndex < columnsCount; columnIndex++ )
      {
        rowSum = rowSum + matrix[rowIndex, columnIndex];
      }
      Console.WriteLine("The sum of Row {0} is {1} ", rowIndex, rowSum);
    }
