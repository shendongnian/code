    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    public List<Entity> ParseEntityExclusionFile(List<string> entries, string urlFile)
    {
        entries.RemoveAt(0);
        
        const char l = '(';
        const char r = ')';
        const char c = ',';
        const char a = '"';
      
        List<Entity> entities = new List<Entity>();
        foreach (string line in entries)
        {
            var splitL = line.Split(l); //(
            var partsList = new List<string>();
            foreach (var value in splitL)
            {
                if (value.Contains(r))//)
                {
                    var splitR = value.Split(r);//)
                    partsList.Add(splitR[0]);
                    if (!line.EndsWith(r))
                    {
                        partsList.AddRange(splitR[1].Remove(0, 1).Split(c));//,
                    }
                }
                else
                {
                    if (!line.StartsWith(l))
                    {
                        partsList.AddRange(value.Remove(value.Length - 1).Split(c));//,
                    }
                }
            }
          
            var lineParts = partsList.ToArray();//{ "One", "Two", "OneB, TwoB", "Five" };
            entities.Add(new Entity
            {
                Id = 1000,
                Names = lineParts[3],
                Identifier = $"{lineParts[25]} | Classification: {lineParts[0]}";
            });
        }
        return entities;
      }
