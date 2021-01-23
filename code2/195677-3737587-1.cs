    using System;
    using System.IO;
    class Program
    {
      static void Main(string[] args)
      {
        ReadFromFile(@"C:\file.txt");
        Console.ReadLine();
      }
      static void ReadFromFile(string filename)
      {
        string line;
        using (StreamReader sr = File.OpenText(filename))
        {
          line  = sr.ReadLine();
          while (line != null)
          {
            Console.WriteLine(str);
            line = sr.ReadLine();
          }
          sr.Close();
        }
      }
    }
