    public static double GetMedian(int[] pNumbers)  {
      int size = pNumbers.Length;
      int mid = size /2;
      double median = (size % 2 != 0) ? (double)pNumbers[mid] :  
          ((double)pNumbers[mid] + (double)pNumbers[mid-1]) / 2;
      return median;
    }
