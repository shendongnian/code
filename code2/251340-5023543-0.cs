            string set = "abcde";
            
            // Init list
            List<string> subsets = new List<string>();
            // Loop over individual elements
            for (int i = 1; i < set.Length; i++)
            {
                subsets.Add(set[i - 1].ToString());
                List<string> newSubsets = new List<string>();
                // Loop over existing subsets
                for (int j = 0; j < subsets.Count; j++)
                {
                    string newSubset = subsets[j] + set[i];
                    newSubsets.Add(newSubset);
                }
                subsets.AddRange(newSubsets);
            }
            // Add in the last element
            subsets.Add(set[set.Length - 1].ToString());
            subsets.Sort();
            Console.WriteLine(string.Join(Environment.NewLine, subsets));
