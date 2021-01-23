    private void GetPermutations()
    {
        int permutationLength = 4;
        string s = "1,4,14,32,47";
        string[] subS = s.Split(',');
        int[] indexS = new int[permutationLength];
    
        List<string> result = new List<string>();
        IterateNextPerm(permutationLength, indexS, subS, result);
    
        // Result will hold all your genberated data.
    }
    
    private void IterateNextPerm(int permutationLength, int[] pIndexes, string[] subS, List<string> result)
    {
        int maxIndexValue = subS.Count() - 1;
    
        bool isCorrect = true;
        for (int index = 0; index < permutationLength - 1; index++)
        {
            if (pIndexes[index] >= pIndexes[index + 1])
            {
                isCorrect = false;
                break;
            }
        }
        
        // Print result if correct
        if (isCorrect)
        {
            string strNewPermutation = string.Empty;
            for (int index = 0; index < permutationLength; index++)
            {
                strNewPermutation += subS[pIndexes[index]] + ",";
            }
            result.Add(strNewPermutation.TrimEnd(','));
        }
    
        // Increase last index position
        pIndexes[permutationLength - 1]++;
    
        // Check and fix if it's out of bounds
        if (pIndexes[permutationLength - 1] > maxIndexValue)
        {
            int? lastIndexIncreased = null;
    
            // Step backwards and increase indexes
            for (int index = permutationLength - 1; index > 0; index--)
            {
                if (pIndexes[index] > maxIndexValue)
                {
                    pIndexes[index - 1]++;
                    lastIndexIncreased = index - 1;
                }
            }
    
            // Normalize indexes array, to prevent unnecessary steps
            if (lastIndexIncreased != null)
            {
                for (int index = (int)lastIndexIncreased + 1; index <= permutationLength - 1; index++)
                {
                    if (pIndexes[index - 1] + 1 <= maxIndexValue)
                    {
                        pIndexes[index] = pIndexes[index - 1] + 1;
                    }
                    else
                    {
                        pIndexes[index] = maxIndexValue;
                    }
                }
            }
        }
    
        if (pIndexes[0] < maxIndexValue)
        {
            IterateNextPerm(permutationLength, pIndexes, subS, result);
        }
    }
