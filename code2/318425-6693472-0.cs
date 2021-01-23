    public long getCheckSum(string source)
    {
      long checkHold = 0, checkSum = 0, weight = 1;
      foreach (char ch in source)
      {
        checkHold = (long)ch * weight;
        checkSum += checkHold;
        weight += 2;
      }
      return checkSum % 0x7FFFFFFF;
    }
