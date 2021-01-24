    public static class StringPermutator
    {
        /// <summary>
        /// Class to permutate input values
        /// </summary>
        /// <param name="inputValues">An array of inputs to be permutated</param>
        /// <param name="numberOfResults">The number of outputs we want to have</param>
        /// <param name="maxValuesPerRow">The number of values to be combined in each output row</param>
        /// <returns>An IEnumerable of unique permutated string ouptuts</returns>
        public static IEnumerable<string> Permutate<T>(T[] inputValues, int numberOfResults, int maxValuesPerRow)
        {
            HashSet<string> output = new HashSet<string>();
            Random rnd = new Random();
    
            //Loop until we have the number of results we want
            while (output.Count < numberOfResults)
            {
                StringBuilder sb = new StringBuilder();
                HashSet<int> usedIndexes = new HashSet<int>();
    
                //Loop until we have the right number of values in a single row
                while (usedIndexes.Count < maxValuesPerRow)
                {
                    int index = rnd.Next(inputValues.Length);
    				//Ensure that each index we use is unique and only used once per row
                    if (usedIndexes.Add(index))
                        sb.Append(inputValues[index].ToString()).Append(",");
                }
    
                sb.Length--;    //remove the last comma
                output.Add(sb.ToString());   //value is only added if unique
            }
    
            return output.ToList();
        }
    }
