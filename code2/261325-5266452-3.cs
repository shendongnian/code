    public Tuple<string,string,string> SplitIntoVariables(string[] input)
        {
            string pieces[] = input.Split(',');
            return Tuple.Create(pieces[0],pieces[1],pieces[2]);
        }
