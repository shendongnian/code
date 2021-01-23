    public enum PrintMode
    {
      File,
      Raw
    }
    
    public static void Print(string printData, PrintMode mode)
    {
      if(mode == PrintMode.Raw)
      {
        //Print the string itself
      }
      else if (mode == PrintMode.File)
      {
        //Print the document in the filepath
      }
      else
      {
        throw new ArgumentException("Invalid print mode specified");
      }
    }
    public static void PrintString(string input)
    {
      Print(input, PrintMode.Raw);
    }
    public static void PrintFile(string input)
    {
      Print(input, PrintMode.File);
    }
