    public string[,] SplitArrays(string[] arrayin) {
      if (null == arrayin)
        return null;
      else if (arrayin.Length <= 0)
        return new string[0, 0];
      // null : we don't know size (number of columns) before 1st line split
      string[,] result = null;
      int row = 0;
      foreach (var line in arrayin) {
        string[] items = line.Split('|');
        // - 2 : skip the very first and the very last items which are empty
        if (null == result)
          result = new string[arrayin.Length, items.Length - 2];
        // if line is too short, let's pad result with empty strings
        for (int col = 0; col < result.GetLength(1); ++col)
          result[row, col] = col + 1 < items.Length - 1 
            ? items[col + 1] 
            : "";            // padding
        row += 1;
      }
      return result;
    }
