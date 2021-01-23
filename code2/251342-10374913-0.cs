        static List<List<T>> GetSubsets<T>(IEnumerable<T> Set)
        {
            var set = Set.ToList<T>();
            
            // Init list
            List<List<T>> subsets = new List<List<T>>();
            subsets.Add(new List<T>()); // add the empty set
            // Loop over individual elements
            for (int i = 1; i < set.Count; i++)
            {
                subsets.Add(new List<T>(){set[i - 1]});
                List<List<T>> newSubsets = new List<List<T>>();
                // Loop over existing subsets
                for (int j = 0; j < subsets.Count; j++)
                {
                    var newSubset = new List<T>();
                    foreach(var temp in subsets[j])
                        newSubset.Add(temp);
                    newSubset.Add(set[i]);
                    newSubsets.Add(newSubset);
                }
                subsets.AddRange(newSubsets);
            }
            // Add in the last element
            subsets.Add(new List<T>(){set[set.Count - 1]});
            //subsets.Sort();
            return subsets;
        }
