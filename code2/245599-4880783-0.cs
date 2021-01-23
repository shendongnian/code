    private string RenderType(string render, Func<string, string> lookupFunc, string prefix, string regexWild, string suffix)
    {
        string regex = prefix + regexWild + suffix;
    
        MatchCollection matches = Regex.Matches(render, regex);
    
        foreach (Match match in matches)
        {
            foreach (Capture capture in match.Captures)
            {
                string name = capture.Value.Replace(prefix, "", StringComparison.CurrentCultureIgnoreCase).Replace(suffix, "", StringComparison.CurrentCultureIgnoreCase);
    
                //-- point of difference
                string value = lookupFunc(name);
    
                render = render.Replace(capture.Value, value);
            }
        }
    
        return render;
    }
