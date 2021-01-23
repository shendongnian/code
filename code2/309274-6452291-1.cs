    public string MyFunction(params object[] someobjects)
    {
         var asstrings = someobjects.Select(o => (o??"").ToString());
         // for example
         return string.Join(", ", asstrings.ToArray());
    }
