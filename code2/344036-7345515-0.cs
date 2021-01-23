    private static int[] GetIndicesOf(byte[] needle, byte[] haystack)
    {
        int[] foundIndices = new int[needle.Length];
            
        int found = 0;
        for (int i = 0; i < haystack.Length; i++)
        {
                
            if (needle[found] == haystack[i])
            {
                if (found > 0)
                {
                    if (foundIndices[found - 1] < i - 1)
                    {
                        found = 0;    // Gap found, reset, maybe later in the haystack another occurrance of needle[0] is found
                        continue;
                    }
                }
                foundIndices[found++] = i;
                if (found == needle.Length)
                    return foundIndices;
            }
        }
        return null;            
    }
