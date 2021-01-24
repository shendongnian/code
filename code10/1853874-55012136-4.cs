    private static string RemoveLeadingTab(string input)
    {
        var result = "";
        var count = Math.Min(4, input?.Length ?? 0);
        int index = 0;
        for (; index < count; index++)
        {
            if (!char.IsWhiteSpace(input[index])) break;
            if (input[index] == ' ') continue;
            if (input[index] == '\t')
            {
                index++;
                break;
            }
                
            if (char.IsWhiteSpace(input[index]))
            {
                result += input[index]; // Preserve other whitespace characters(?)
                if (input.Length > count + 1) count++;
            }
        }
        return result + input?.Substring(index);
    }
