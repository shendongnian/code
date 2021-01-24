     private void SaveNewUser(string name, int score) {
       var newDictionary = AllNames()
         .GroupBy(pair => pair.Value)     // groups by scores                    
         .OrderBy(chunk => chunk.Key)     // less seconds the better
         .Take(4)                         // at most 4 groups (ties preserved)         
         .SelectMany(chunk => chunk)      // flatten back ("ungroup")
         .ToDictionary(pair => pair.Key, 
                      pair => pair.Value);
       newDictionary.Add(name, score);
 
       File.WriteAllLines(@"c:\TopPlayers.txt", newDictionary
         .Select(pair => $"{pair.Key} {pair.Value}"));
     }
