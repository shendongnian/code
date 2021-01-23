    using System;
    using System.IO;
    namespace ExtractData
    {
      class Program
      {
        static void Main(string[] args)
        {
          foreach (var line in File.ReadAllLines("test.txt"))
          { Console.WriteLine(line); }
          Console.ReadKey();
        }
      }
    }
