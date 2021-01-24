    using System.Linq;
    using System.Collections.Generic;
    static void Test()
    {
      string delimiterStart = "Seq Started";
      string delimiterEnd = "Seq Ended";
      string filenameSource = "c:\\sample source.txt";
      string filenameDest = "c:\\sample dest.txt";
      var result = new List<string>();
      var lines = File.ReadAllLines(filenameSource);
      int indexStart = -1;
      int indexEnd = -1;
      for ( int index = 0; index < lines.Length; index++ )
      {
        if ( lines[index].Contains(delimiterStart) )
          if ( indexStart == -1 )
            indexStart = index + 1;
          else
          {
            Console.WriteLine($"Only one \"{delimiterStart}\" is allowed in file {filenameSource}.");
            indexStart = -1;
            break;
          }
        if ( lines[index].Contains(delimiterEnd) )
        {
          indexEnd = index;
          break;
        }
      }
      if ( indexStart != -1 && indexEnd != -1 )
      {
        result.AddRange(lines.Skip(indexStart).Take(indexEnd - indexStart));
        File.WriteAllLines(filenameDest, result);
        Console.WriteLine($"Content of file \"{filenameSource}\" extracted to file {filenameDest}.");
      }
      else
      {
        if ( indexStart == -1 )
          Console.WriteLine($"\"{delimiterStart}\" not found in file {filenameSource}.");
        if ( indexEnd == -1 )
          Console.WriteLine($"\"{delimiterEnd}\" not found in file {filenameSource}.");
      }
    }
