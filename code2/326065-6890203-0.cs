    public static IEnumerable<string> ReturnString(IEnumerable<IEnumerable<string>> matrix)
    {
        if (matrix.Count() == 1)
            return matrix.First();
    
        var result = from letter in matrix.First()
                     let tails = ReturnString(matrix.Skip(1))
                     from t in tails
                     select new[] { letter, t };
    
        //return result.Select(r => r.Aggregate((acc, next) => acc + next));
        return result.Select(r => r.Aggregate(new StringBuilder(), (acc, next) => acc.Append(next)).ToString());
    }
