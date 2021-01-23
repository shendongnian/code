    public static IEnumerable<string> Permutations(this string text)
    {
        return PermutationsImpl(string.Empty, text);
    }
    private static IEnumerable<string> PermutationsImpl(string start, string text)
    {
        if (text.Length <= 1)
            yield return start + text;
        else
        {
            for (int i = 0; i < text.Length; i++)
            {
                text = text[i] +
                        text.Substring(0, i) +
                        text.Substring(i + 1);
                foreach (var s in PermutationsImpl(start +
                    text[0], text.Substring(1)))
                    yield return s;
            }
        }
    }
