    using System.IO;
    using System.Collections.Generic;
    static void Test()
    {
      var lines = File.ReadAllLines(@"c:\\sample.txt");
      var dataUM = new List<string>();
      var dataColumn1 = new List<string>();
      var dataColumn2 = new List<string>();
      var dataColumn3 = new List<string>();
      int indexEndColumn1 = 24;
      int indexEndColumn2 = 40;
      int indexEndColumn3 = 0; /* data provided by OP are not aligned */
      Action<string, int, List<string>> extractData = (str, end, list) =>
      {
        int indexStart = -1;
        for ( int index = end - 1; index >= 0; index-- )
          if ( str[index] == ' ' )
          {
            indexStart = index;
            break;
          }
        if ( indexStart != -1 )
          list.Add(str.Substring(indexStart + 1, end - 1 - indexStart));
      };
      foreach ( string line in lines )
      {
        int indexEnd = line.IndexOf("(um)");
        if ( indexEnd != -1 )
          extractData(line, indexEnd, dataUM);
        else
        if ( line.StartsWith("Sn") )
        {
          extractData(line, indexEndColumn1, dataColumn1);
          extractData(line, indexEndColumn2, dataColumn2);
          extractData(line, indexEndColumn3, dataColumn3);
        }
      }
      Action<string, List<string>> printData = (title, list) =>
      {
        Console.WriteLine(title);
        foreach ( var item in list )
          Console.WriteLine(item);
        Console.WriteLine();
      };
      printData("Data content for (um)", dataUM);
      printData("Data content for Column 1", dataColumn1);
      printData("Data content for Column 2", dataColumn2);
      printData("Data content for Column 3", dataColumn3);
    }
