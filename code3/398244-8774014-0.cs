    bool IsSomethingValid(stging source, string shouldContain, string pattern)
    {
        bool res = source.Contains(shouldContain);
        if (res)
        {
             var regex = new Regex(pattern, RegexOptions.Compiled);
             res = regex.IsMatch(source);
        }
        return res;
    }
