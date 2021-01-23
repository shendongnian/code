    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    
    namespace LinqToText
    {
      class Program
      {
          
        static void Main(string[] args)
        {
            using (TextReader reader = File.OpenText(@"D:\Data\Mock\mock_data.csv"))
                {
                    ProcessBatches(reader, line => line.Contains("#"), BatchAction); 
                } 
            Console.WriteLine("End Of Processing");
            Console.Read();
    
        }
    
          public static void ProcessBatches(TextReader reader, Func<string, bool> delimiterDetector,Action<List<string>> batchAction)
          {
              string line;
              var batch = new List<string>();
              var counter = 0;
              while ((line = reader.ReadLine()) != null)
              {
                  if (delimiterDetector(line) && counter !=0)
                  {
                      
                      batchAction(batch);
                      batch = new List<string>();
                  }
                  batch.Add(line);
                  counter++;
              }
              batchAction(batch);
          }
          private static void BatchAction(List<string> batch) 
            {
              Console.WriteLine("Processing a single batch...................");
              foreach (var str in batch)
              {
                  Console.WriteLine(str);
              }
              Console.WriteLine("End of single batch processing...................");
              Thread.Sleep(1000);
    
            } 
    
    
      }
    }
