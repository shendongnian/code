    public static void Print(List<KeyValuePair<string,int>> list)
    {
       // get the max length of all the words so we can align
       var max = list.Max(x => x.Key.Length);
    
       foreach (var item in list)
       {
          // right align using PadLeft and max length
          Console.Write(item.Key.PadLeft(max));
          Console.Write(" ");
         
          // change color
          Console.BackgroundColor = ConsoleColor.DarkBlue;
    
          // Write the bars
          for (var i = 0; i < item.Value; i++)
             Console.Write("#");
    
          // change back
          Console.BackgroundColor = ConsoleColor.Black;
    
          Console.Write(" ");
          // this creates the new line
          Console.WriteLine(item.Value);
       }
    }
