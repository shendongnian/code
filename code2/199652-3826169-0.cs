    using System;
    
    namespace ConsoleApplication1
    {
       class Program
       {
          static void Main(string[] args)
          {
             // since specified strings are treated on the fly as string objects...
             string limit5 = "The quick brown fox jumped over the lazy dog.".LimitLength(5);
             string limit10 = "The quick brown fox jumped over the lazy dog.".LimitLength(10);
             // this line should return us the entire contents of the test string
             string limit100 = "The quick brown fox jumped over the lazy dog.".LimitLength(100);
    
             Console.WriteLine("limit5   - {0}", limit5);
             Console.WriteLine("limit10  - {0}", limit10);
             Console.WriteLine("limit100 - {0}", limit100);
    
             Console.ReadLine();
          }
       }
    
       public static class StringExtensions
       {
          /// <summary>
          /// Method that limits the length of text to a defined length.
          /// </summary>
          /// <param name="source">The source text.</param>
          /// <param name="maxLength">The maximum limit of the string to return.</param>
          public static string LimitLength(this string source, int maxLength)
          {
             if (source.Length <= maxLength)
             {
                return source;
             }
    
             return source.Substring(0, maxLength);
          }
       }
    }
