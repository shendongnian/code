    Regex rg = new Regex(s1, RegexOptions.Multiline | RegexOptions.IgnoreCase);
    Match mt = rg.Match(resultadoEjecucionScriptMsBuild);
    if (!mt.Success)
    {
        rg = new Regex(s11, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        mt = rg.Match(resultadoEjecucionScriptMsBuild);
        if (!mt.Success)
        {
            rg = new Regex(s12, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            mt = rg.Match(resultadoEjecucionScriptMsBuild);
            if (!mt.Success) return false;
        }
    }
