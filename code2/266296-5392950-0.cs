    static public IEnumerable<string> permute(string template)
    {
        List<string> options;
        string before;
        string after;
        if (FindFirstOptionList(template, out options, out before, out after))
        {
            foreach (string option in options)
            {
                foreach (string permutation in permute(before + option + after))
                {
                    yield return permutation;
                }
            }
        }
        else
        {
            yield return template;
        }
    }
