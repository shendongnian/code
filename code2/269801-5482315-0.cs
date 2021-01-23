    // this is a private class-scope variable.
    private static string prevMonthName = string.Empty;
    public string GetMonth(string curMonthName)
    {
      if (curMonthName == prevMonthName)
      {
        return string.Empty;
      }
      prevMonthName = curMonthName;
      return curMonthName;
    }  
