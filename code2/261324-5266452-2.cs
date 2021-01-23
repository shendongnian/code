    public void SplitIntoVariables(string input, out a, out b, out c)
    {
        string pieces[] = input.Split(',');
        a = pieces[0];
        b = pieces[1];
        c = pieces[2];
    }
