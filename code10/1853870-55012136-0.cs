    private static string RemoveLeadingTab(string input)
    {
        var count = Math.Min(4, input?.Length ?? 0);
        for (var i = 0; i < count; i++)
        {
            if (input[i] == '\t')
            {
                input = input.Substring(1);
                break;
            }
            if (input[i] == ' ')
            {
                input = input.Substring(1);
                continue;
            }
            if (!char.IsWhiteSpace(input[i])) break;
        }
        return input;
    }
