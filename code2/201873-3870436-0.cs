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
            if (state.Count == 0 && separators.Contains(c) && (c != ' ' || !separators.Contains(input[i + 1])))
            {
                yield return new KeyValuePair<char?, string>(c, input.Substring(index, i - index).TrimEnd());
                while (++i < input.Length && input[i] == ' ') { }
                index = i;
            }
        }
        yield return new KeyValuePair<char?, string>(null, input.Substring(index));
    }
