    private static int[] GetIndicesOf(byte[] needle, byte[] haystack)
    {
        int[] foundIndices = new int[needle.Length];
            
        int found = 0;
        for (int i = 0; i < haystack.Length; i++)
        {
            if (needle[found] == haystack[i])
            {
                foundIndices[found++] = i;
                if (found == needle.Length)
                    return foundIndices;
            }
            else
            {
                i -= found;   // Re-evaluate from the start of the found sentence + 1
                found = 0;    // Gap found, reset, maybe later in the haystack another occurrance of needle[0] is found
                continue;
            }
        }
        return null;            
    }
