    internal static string NormalizeWhiteSpace(string input, char normalizeTo = ' ')
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;
    
        int current = 0;
        char[] output = new char[input.Length];
        bool skipped = false;
    
        foreach (char c in input.ToCharArray())
        {
            if (char.IsWhiteSpace(c))
            {
                if (!skipped)
                {
                    if (current > 0)
                        output[current++] = normalizeTo;
      
                    skipped = true;
                }
            }
            else
            {
                skipped = false;
                output[current++] = c;
            }
        }
    
        return new string(output, 0, skipped ? current - 1 : current);
    }
