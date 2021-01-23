    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.Linq;
    
    namespace LinqToText
    {
      class Program
      {
          
        static void Main(string[] args)
        {
            var csvLines = new List<string>();
            var contextIndexes = new List<int>();
            int counter = 0;
    
    
            var instream = FastReadCsvFile(@"D:\Data\Mock\mock_data.csv");
            foreach (var str in instream)
            {
                if(str.Contains("#"))
                {
                    contextIndexes.Add(counter);
                }
                counter++;
            }
            contextIndexes.Add(instream.Count());
    
            foreach (var indexes in contextIndexes)
            {
                Console.WriteLine(indexes);
            }
            int[] ixpos = contextIndexes.ToArray();
    
      
            for(int i = 0 ;i< ixpos.Length-1;i++)
            {
                int strtPos = ixpos[i];
                int endPos = ixpos[i+1];
                var batch = instream.Skip(strtPos).Take(endPos - strtPos);
                foreach (var dt in batch)
                {
                    Console.WriteLine(dt);
                }
            }
            Console.WriteLine("End Of Processing");
            Console.Read();
    
        }
    
          private static IEnumerable<string> FastReadCsvFile(string file)
          {
              using (var reader = new StreamReader(file, Encoding.Default))
              {
                  string line;
                  while ((line = reader.ReadLine()) != null)
                  {
                      yield return line;
                  }
              }
          }
      }
    }
    
    
    
    
                
