    var characterSets = new string[] { "NOTION", "CATION", "COIN", "NOON" }
           .SelectMany(c => c.GroupBy(cc => cc)) // create character groups for each string, and flatten the groups
           .GroupBy(c => c.Key) // group the groups
           .OrderBy(cg => cg.Key) // order by the character (alphabetical)
           .Select(cg => new string(cg.Key, cg.Max(v => v.Count()))) // create a string for each group, using the maximum count for that character
           .ToArray(); // make an array
    var result = string.Concat(characterSets);
