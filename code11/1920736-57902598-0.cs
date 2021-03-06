       using System.IO; 
       using System.Linq;
       ...
       public static List<Settlement> ReadFromLogFile() {
         string filename = Path.Combine(path, @"BM_DB_MIGRATION.txt");
    
         if (File.Exists(filename)) {
           return File
             .ReadLines(filename)
             .Select((line, index) => new {
                line,
                index
              }) 
             .GroupBy(item => item.index / 7, // group of [0..6] lines, then [7..13] lines etc. 
                      item => item.line)
             .Select(group => new Settlement(
                group.ElementAtOrDefault(0),
                group.ElementAtOrDefault(1),
                group.ElementAtOrDefault(2), 
                group.ElementAtOrDefault(3),  
                group.ElementAtOrDefault(4),
                group.ElementAtOrDefault(5), 
                group.ElementAtOrDefault(6)  
              ))
             .ToList();  
         }
    
         return new List<Settlement>(); 
       }
