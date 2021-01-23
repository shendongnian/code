    internal static IEnumerable<KeyValuePair<char?, string>> SplitUnescaped(this string input, char[] separators)
    {
        int startIndex = 0;
        var state = new Stack<char>();
        input = input.Trim(separators);
        for (int i = 0; i < input.Length; ++i)
        {
            char c = input[i];
            char s = state.Count > 0 ? state.Peek() : default(char);
            if (state.Count > 0 && (s == '\\' || (s == '[' && c == ']') || ((s == '"' || s == '\'') && c == s)))
                state.Pop();
            else if (c == '\\' || c == '[' || c == '"' || c == '\'')
                state.Push(c);
            else if (state.Count == 0 && separators.Contains(c))
            {
                int endIndex = i;
                while (input[i] == ' ' && separators.Contains(input[i + 1])) { ++i; }
                yield return new KeyValuePair<char?, string>(input[i], input.Substring(startIndex, endIndex - startIndex));
                while (input[++i] == ' ') { }
                startIndex = i;
            }
        }
        yield return new KeyValuePair<char?, string>(null, input.Substring(startIndex));
    }
