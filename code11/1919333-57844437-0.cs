    using System;
    
    public class Kata
    {
      public static string Rgb(byte r, byte g, byte b) 
      {
        return String.Format("{0:X2}{1:X2}{2:X2}", r, g, b);
      }
    }
