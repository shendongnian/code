    using System;
    using System.Text;
    
    public static class SOQ {
      public static void Main( string[] argv ){
    
        Console.Error.Write("Enter the number of characters: ");
    
        // far from ideal but illustrates your code
        var count = int.Parse(Console.ReadLine());
    
        var buffer = new StringBuilder();
    
        for ( int i = 0; i < count; i++ ){
          Console.Error.Write("\n{0}:",i+1);
          var c = (char)Console.Read();
          buffer.Append(c.ToString());
        }
    
        Console.WriteLine();
        Console.WriteLine("Result: `{0}'", buffer.ToString());
    
      }
    }
