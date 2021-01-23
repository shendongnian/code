    public Tuple<string,string> SplitIntoVars(string toSplit)
    {
       string[] split = toSplit.Split(',');
       return Tuple.Create(split[0],split[1]);
    }
