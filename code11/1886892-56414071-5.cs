    using System.Linq;
    
    // ...
    
    string[] lines = File.ReadAllLines(INILoc);
    string[] linesTillNames = lines
                              .Take( // Take just N items from the array
                                  Array.IndexOf(lines, "[names]") // Until the index of [names]
                              )
                              .ToArray();
    File.WriteAllLines(INILoc, linesTillNames);
