    using System;
    
    public enum DivisionStatus
    {
      None = 'N',
      Active = 'X',
      Inactive = 'I',
      Waitlist = 'W'
    }
    
    class Program
    {
      public static void Main()
      {
        var ds = DivisionStatus.Active;
        Console.WriteLine((char)ds);
      }
    }
