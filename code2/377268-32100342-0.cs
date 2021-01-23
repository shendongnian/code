    using System;
 
    public class Program
    {
       public void Main()
       {
          Console.WriteLine(" Hello World! ".CenterString(80, '#'));
       }
    }
 
    public static class StringExtensions
    {
       public static string CenterString(this string stringToCenter, int totalLength)
       {
          return stringToCenter.PadLeft(
              ((totalLength - stringToCenter.Length) / 2) 
                + stringToCenter.Length).PadRight(totalLength);
       }
 
       public static string CenterString(this string stringToCenter, 
                                              int totalLength, 
                                              char paddingCharacter)
       {
          return stringToCenter.PadLeft(
              ((totalLength - stringToCenter.Length) / 2) + stringToCenter.Length,
                paddingCharacter).PadRight(totalLength, paddingCharacter);
       }
    }
