    public static decimal GetStringPercentage(string s1, string s2)
    {
         decimal matches = 0.0m;
         List<string> s1Split = s1.Split(' ').ToList();
         List<string> s2Split = s2.Split(' ').ToList();
    
         if (s1Split.Count() > s2Split.Count())
         {
             foreach (string s in s1Split)
                 if (s2Split.Any(st => st == s))
                     matches++;
    
                 return matches / s1Split.Count();
         }
         else
         {
             foreach (string s in s2Split)
                 if (s1Split.Any(st => st == s))
                      matches++;
    
             return (matches / s2Split.Count());
         }
                
    }
