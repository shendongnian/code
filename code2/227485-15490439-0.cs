    public static class Logger
    {        
         public static StringBuilder LogString = new StringBuilder(); 
         public static void Out(string str)
         {
             Console.WriteLine(str);
             LogString.Append(str).Append(Environment.NewLine);
         }
     }
