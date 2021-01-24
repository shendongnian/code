    Actions.Add(new Action(() => Console.WriteLine(ReplaceVars(ToPrint, VarsToPrint))));
    string ReplaceVars(string s, IEnumerable<string> vars) {
        var values = VarsToPrint.Select(varname => Variables[varname]); // fetch the values associated with the variable names (uses System.Linq)
        return string.Format(s, values.ToArray()); // replace {0}, {1}, {2}... with the values fetched
    }
