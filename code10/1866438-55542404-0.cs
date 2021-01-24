    public static List<string> SMSMessage(string message, int maxLength)
    {
      var accumulator = new List<string>();
      SMSMessage(accumulator, message, maxlength);
      return accumulator;
    }
    private static void SMSMessage(
      List<string> accumulator, 
      string message, 
      int maxLength)
    { 
      // IF (BASE CASE) { DO BASE CASE, RETURN }
      // DO RECURSIVE CASE, RETURN
    }
