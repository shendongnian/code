static int FindRun(string s, int start, int length)
{
    if (start + length >= s.Length) return 0;
    int numRuns = 0;
    string pattern = s.Substring(start, length);
    for (int i = start + length; i <= s.Length - length; i += length)
    {
        if (s.Substring(i, length) == pattern) numRuns += 1;
        else break;
    }
    return numRuns;
}
static string EncodeString(string src)
{
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < src.Length; i++)
    {
        string theRun = null;
        int numRuns = 0;
        // Find runs of lengths 4, 3, 2, 1
        for (int j = 4; j >= 1; j--)
        {
            int runs = FindRun(src, i, j);
            if (runs > 1)  // Run found!
            {
                // Save it for later. Want to append the longest run
                theRun = src.Substring(i, j);
                numRuns = runs;
            }
        }
        // No run? Just append the letter
        if (theRun == null)
        {
            sb.Append(src[i]);
        }
        else
        {
            // This is the size of the run
            int replacementStringSize = (numRuns * theRun.Length) + (theRun.Length - 1);
            // This is the code to use as a replacement
            String runCode = String.Format("[{0}#$%{1}]", theRun, numRuns + 1);
            // Only append if the code length is smaller than the original run
            if (runCode.Length < replacementStringSize)
            {
                sb.Append(runCode);
            }
            else
            {
                // Don't encode. Put original run back
                for (int j = 0; j <= numRuns; j++)
                {
                    sb.Append(theRun);
                }
            }
            // Skip over the run
            i += replacementStringSize;
        }
    }
    return sb.ToString();
}
