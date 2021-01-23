            var groups = new List<List<string>>();
   
            foreach (var line in lines)
            {
                if (line.StartsWith("Start:"))
                {
                    groups.Add(new List<string>());
                }
                groups[groups.Count - 1].Add(line);
            }
