    using System;
    using System.IO;
    using System.Collections.Generic;
    
    public class Program
    {
      private static int Compare(KeyValuePair<string, int> kv1, KeyValuePair<string, int> kv2)
      {
        return kv2.Value == kv1.Value ? kv1.Key.CompareTo(kv2.Key) : kv2.Value - kv1.Value;
      }
    
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
    
        List<KeyValuePair<string, int>> sortedHistogram = new List<KeyValuePair<string, int>>(histogram);
        sortedHistogram.Sort(Compare);
        foreach (KeyValuePair<string, int> kv in sortedHistogram)
          Console.WriteLine("{0}\t{1}", kv.Value, kv.Key);
      }
    }
