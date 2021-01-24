    using System.Linq;
    ...
    var lines = File
      .ReadLines(txtFile)
      .SkipWhile(line => !line.Contains("(1)"))         // Skip all lines before "...(1)..." 
      .SkipWhile(line => !line.Contains("-------------------")) // -/- "----"
      .Skip(1)                                          // Skip "----" itself
      .TakeWhile(line => !line.Contains("XXXXXXXXXX"))  // Take all lines before "...XXXXXX..."
      .ToArray();                                       // Have lines as an array 
