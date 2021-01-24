    int rows = 30;
    int cols = 10;
    bool[,] grid = new bool[rows,cols];
    InitializeGrid(grid);
    for (int row = 0 ; row < rows ; ++row )
    {
      bool isAllTrue = true;
      
      for( int col = 0 ; col < cols ; ++col {
        if ( !grid[row,col] )
        {
          isAllTrue = false;
          break;
        }
        
      }
      
      if (isAllTrue)
      {
        Console.WriteLine($"Row {row} is all true");
      }
      
    }
