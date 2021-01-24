    using System.Linq;
    ...
    // string[] {"Check_Amt", "DBO"}
    var values = File 
      .ReadLines(@"c:\MyFile.txt")
      .Select(line => line.Split(new char[] { '=' }, 2)) // split into name, value pairs
      .Where(items => items.Length == 2)                 // to be on the safe side
      .Where(items => items[0] == "Name")                // name == "Name" only
      .Select(items => items[1])                         // value from name=value
      .ToArray();                                        // let's have an array
