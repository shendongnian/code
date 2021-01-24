    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
             const string INPUT_FILENAME = @"c:\temp\test.txt";
             const string OUTPUT_FILENAME = @"c:\temp\test1.txt";
             static void Main(string[] args)
             {
                 List<SortLines> lines = new List<SortLines>();
                 StreamReader reader = new StreamReader(INPUT_FILENAME);
                 string line = "";
                 while ((line = reader.ReadLine()) != null)
                 {
                     line = line.Trim();
                     if (line.Length > 0)
                     {
                         line = line.Replace(" ", "*");
                         SortLines newLine = new SortLines() { key = line.Substring(2, 7), line = line };
                         lines.Add(newLine);
                     }
                 }
                 reader.Close();
                 var groups = lines.GroupBy(x => x.key);
                 StreamWriter writer = new StreamWriter(OUTPUT_FILENAME);
                 foreach (var group in groups)
                 {
                     foreach (SortLines sortLine in group)
                     {
                         writer.WriteLine(sortLine.line);
                     }
                 }
                 writer.Flush();
                 writer.Close();
      
             }
        }
        public class SortLines : IComparable<SortLines>
        {
            public string line { get; set; }
            public string key { get; set; }
            public int CompareTo(SortLines other)
            {
                return key.CompareTo(other);
            }
        }
       
       
    }
