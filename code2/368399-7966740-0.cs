      // I am using this as your source of numbers, I am just guessing that it is reasonably close enough to the real thing.  Yuo could just as easily use a 2D array here.
      List<int[]> numberArray = GetMyNumbers();
      // Placeholder for the lowest averge / corresponding index.
      double lowestAvg = double.MaxValue;
      int lowestIndex = -1;
      for (int rowIndex = 0; rowIndex < numberArray.Count; rowIndex++)
      {
        {
          int[] row = numberArray[rowIndex];
          int n = row.Length;
          int[] diffs = new int[(n * n) - n];
          // Get all of the differences.
          int count = 0;
          for (int i = 0; i < n; i++)
          {
            for (int j = i + 1; j < n; j++)
            {
              diffs[count] = Math.Abs(row[i] - row[j]);
              count++;
            }
          }
          // Average them..
          double sum = 0;
          for (int i = 0; i < diffs.Length; i++)
          {
            sum += diffs[i];
          }
          double avg = sum / diffs.Length;
          // Compare to the lowest value, making note of a new low.
          if (avg < lowestAvg)
          {
            lowestAvg = avg;
            lowestIndex = rowIndex;
          }
        }
      }
      // Now that we are here, we know which index has the lowest average of differences.
      // Do whatever you want with it.
      int[] TheAnswer = numberArray[lowestIndex];
