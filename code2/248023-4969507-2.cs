    public static string DeleteLines(string s, int linesToRemove)
    {
        return s.Split(Environment.NewLine.ToCharArray(), 
                       linesToRemove + 1
            ).Skip(linesToRemove)
            .FirstOrDefault();
    }
