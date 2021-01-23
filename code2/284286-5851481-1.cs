    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          var strings = File.ReadAllLines("Text.txt");
    
          Stopwatch sw;
    
          StringBuilder sb = new StringBuilder();
    
          sw = Stopwatch.StartNew();
          for (int i = 0; i < strings.Length; i++)
          {
            sb.AppendLine(strings[i]);
          }
          sw.Stop();
          TimeSpan sbTime = sw.Elapsed;
    
          sw = Stopwatch.StartNew();
         var output = string.Join(",", strings);
         sw.Stop();
    
         TimeSpan joinTime = sw.Elapsed;   
    
        }
      }
    }
