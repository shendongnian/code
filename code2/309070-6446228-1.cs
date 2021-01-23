                List<string> firstNames = new List<string>();
                firstNames.Add("John");
                firstNames.Add("Mary");
                firstNames.Add("Jane");
    
                // Only do this if there is more than one name
                if (firstNames.Count > 1)
                {
                    string separator = ", ";
                    // Join the names, using ", " as a separator
                    string names = String.Join(seperator, firstNames.ToArray());
                    // Insert "and" before the last comma
                    names = names.Insert(names.LastIndexOf(separator), ", and ");
                    // Remove the last comma
                    names = names.Remove(names.LastIndexOf(separator), separator.Length);
                }
