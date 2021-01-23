    using System;
    using System.IO;
    
    namespace ExtractData
    {
      class Program
      {
        static void Main(string[] args)
        {
          StreamReader sr = File.OpenText("test.txt");
          string line;
          while ((line = sr.ReadLine()) != null)
          { Console.WriteLine(line); }
    
          sr.Close();
          Console.ReadKey();
        }
      }
    }
