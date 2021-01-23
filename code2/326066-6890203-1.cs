    public static IEnumerable<string> ReturnString(IEnumerable<IEnumerable<string>> matrix)
    {
        if (matrix.Count() == 1)
            return matrix.First();
    
        var result = from letter in matrix.First()
                     let tail = matrix.Skip(1).SkipWhile(lst => !lst.Any())
                     let tailStrings = ReturnString(tail)
                     from str in tailStrings
                     select new[] { letter, str };
    
        //return result.Select(r => r.Aggregate((acc, next) => acc + next));
        return result.Select(r => r.Aggregate(new StringBuilder(), (acc, next) => acc.Append(next)).ToString());
    }
