      //DONE: static : we don't want "this" here
      public static void SetArrayElement(int row, int col)
      {
         //DONE: validate public method's values
         if (row < array.GetLowerBound(0) || row > array.GetUpperBound(0))
             throw new ArgumentOutOfRangeException(nameof(row));
         else if (col < array.GetLowerBound(1) || col > array.GetUpperBound(1))
             throw new ArgumentOutOfRangeException(nameof(col)); 
         array[row, col] = true; // true, instead of 1
      }
