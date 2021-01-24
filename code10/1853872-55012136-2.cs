    private static string RemoveLeadingTab(string input)
    {
        var result = input;
        var count = Math.Min(4, input?.Length ?? 0);
        for (var i = 0; i < count; i++)
        {
            if (input[i] == '\t')
            {
                result = result.Substring(1);
                break;
            }
            if (input[i] == ' ')
            {
                result = result.Substring(1);
                continue;
            }
            if (!char.IsWhiteSpace(input[i])) break;
        }
        return result;
    }
