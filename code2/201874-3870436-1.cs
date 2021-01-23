    internal static IEnumerable<KeyValuePair<char?, string>> SplitUnescaped(this string input, char[] separators)
    {
        int index = 0;
        var state = new Stack<char>();
            
        input = input.Trim();
        for (int i = 0; i < input.Length; ++i)
        {
            char c = input[i];
            char s = state.Count > 0 ? state.Peek() : default(char);
            if (state.Count > 0 && (s == '\\' || (s == '[' && c == ']') || ((s == '"' || s == '\'') && c == s)))
                state.Pop();
            else if (c == '\\' || c == '[' || c == '"' || c == '\'')
                state.Push(c);
            if (state.Count == 0 && separators.Contains(c))
            {
                int j = i;
                while (input[i] == ' ' && separators.Contains(input[i + 1])) { ++i; }
                yield return new KeyValuePair<char?, string>(input[i], input.Substring(index, j - index));
                while (input[++i] == ' ') { }
                index = i;
            }
        }
        yield return new KeyValuePair<char?, string>(null, input.Substring(index));
    }
