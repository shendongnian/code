    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
      public static void Main()
      {
        var histogram = new Dictionary<string, int>();
        using (var reader = new StreamReader("Test.txt"))
        {
          string line;
          while ((line = reader.ReadLine()) != null)
          {
            if (histogram.ContainsKey(line))
              ++histogram[line];
            else
              histogram.Add(line, 1);
          }
        }
        
        var sortedHistogram = (from kv in histogram orderby kv.Value descending select kv).ToList();
        foreach (var kv in sortedHistogram)
          Console.WriteLine("{0}\t{1}", kv.Value, kv.Key);
      }
    }
