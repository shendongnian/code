    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
      public static void Main()
      {
        Dictionary<string, int> histogram = new Dictionary<string, int>();
        using (StreamReader reader = new StreamReader("Test.txt"))
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
        
        foreach (KeyValuePair<string, int> kv in histogram)
          Console.WriteLine("{0}\t{1}", kv.Value, kv.Key);
      }
    }
