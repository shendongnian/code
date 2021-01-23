    static bool IsBracesValidator(string input)
    {
        bool IsValidBraces = true;
        char[] chrArray = input.ToCharArray();
        List<Char> foundOpenParanthesis = new List<char>();
        List<Char> foundClosedParanthesis = new List<char>();
        char[] chrOpenParanthesis = { '{', '[', '(', '<' };
        char[] chrClosedParanthesis = { '}', ']', ')', '>' };
        for (int i = 0; i <= chrArray.Length - 1; i++)
        {
            if (chrOpenParanthesis.Contains(chrArray[i]))
            {
                foundOpenParanthesis.Add(chrArray[i]);
            }
            if (chrClosedParanthesis.Contains(chrArray[i]))
            {
                foundClosedParanthesis.Add(chrArray[i]);
            }
        }
        
        if (foundOpenParanthesis.Count == foundClosedParanthesis.Count)
        {
            for(int i=0;i< foundOpenParanthesis.Count;i++)
            {
                char chr = foundOpenParanthesis[i];
                switch (chr)
                {
                    case '[': chr = ']'; break;
                    case '<': chr = '>'; break;
                    case '(': chr = ')'; break;
                    case '{': chr = '}'; break;
                }
                if (!chr.Equals(foundClosedParanthesis[foundClosedParanthesis.Count - i-1]))
                {
                    IsValidBraces = false;
                    break;
                }
            }
        } else
        {
            IsValidBraces = false;
        }
        return IsValidBraces;
    }
