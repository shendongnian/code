    static string MaskName(ReadOnlySpan<char> name)
    {
        int indexOfComma = name.IndexOf(',');
    
        if (indexOfComma != -1)
        {
            Span<char> temp = stackalloc char[name.Length];
    
            name.CopyTo(temp);
    
            bool isFirstChar = true;
    
            for (int i = indexOfComma + 1; i < temp.Length; i++)
            {
                if (temp[i] == ' ')
                    isFirstChar = true;
                else if (isFirstChar)
                    isFirstChar = false;
                else
                    temp[i] = 'X';
            }
    
            return new string(temp);
        }
        else
        {
            return name.ToString();
        }
    }
