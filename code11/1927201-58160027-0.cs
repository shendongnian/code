    using System.IO;
    using System.Collections.Generic;
    static void Test()
    {
      var lines = File.ReadAllLines(@"c:\\sample.txt");
      var result = new List<string>();
      foreach ( string line in lines )
      {
        int indexEnd = line.IndexOf("(um)");
        if ( indexEnd != -1 )
        {
          int indexStart = -1;
          for ( int index = indexEnd - 1; index >= 0; index-- )
            if ( line[index] == ' ' || line[index] == 'n')
            {
              indexStart = index;
              break;
            }
          if ( indexStart != -1 )
            result.Add(line.Substring(indexStart + 1, indexEnd - 1 - indexStart));
        }
      }
      foreach ( var item in result )
        Console.WriteLine(item);
    }
