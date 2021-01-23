    using System;
    using System.IO;
    namespace ExtractData
    {
      class Program
      {
        static void Main(string[] args)
        {
          using (StreamReader sr = File.OpenText("test.txt"))
          {   
            string line;
            while ((line = sr.ReadLine()) != null)
            { Console.WriteLine(line); }
          }
          Console.ReadKey();
        }
      }
    }
