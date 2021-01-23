    using System;
    
    public class Class1
    {
       public static void Main(string[] args)
       {
          Dictionary<string, string> values = new Dictionary<string, string>();
          // hopefully you have even number args count.
          for(int i=0; i < args.Length; i+=2){
          {
               values.Add(args[i], args[i+1]);
          }
       }
    }
