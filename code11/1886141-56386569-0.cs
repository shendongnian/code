    double[][] myArray = getMeSomeData();
    double[]   factors = getMeSomeRowFactors();
    
    foreach (var row in myArray)
    {
      MultiplyRow(row, factors)
    }
    
    . . .
    void MultiplyRow( double[] row, double[] factors )
    {
      for ( int col = 0 ; col < row.length ; ++col )
      {
        row[col] = row[col] * factors[col];
      }
    }
