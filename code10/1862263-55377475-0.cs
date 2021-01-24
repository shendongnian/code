       IEnumerable<string> result = File
         .ReadLines(@"c:\MyFile.txt")    
         .Where(line => !string.IsNullOrWhiteSpace(line)) // to be on the safe side
         .Select(line => {
            int p = line.IndexOf('|');
            return new {
              date = line.Substring(0, p), // date to take Max
              key = line.Substring(p + 1)  // group key
            };
          })
         .GroupBy(item => item.key, item => item.date)
         .Select(chunk => string.Join("|", chunk.Key, chunk.Max(item => item));
