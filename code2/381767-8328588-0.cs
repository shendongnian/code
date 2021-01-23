    var list = new[] { 
        new DateTime(2011, 1, 1), 
        new DateTime(2011, 1, 2), 
        new DateTime(2011, 1, 3), 
        new DateTime(2011, 1, 5), 
        new DateTime(2011, 1, 6), 
        new DateTime(2011, 1, 8), 
        new DateTime(2011, 1, 10), 
    };
    var ordered = list.OrderBy(d => d);
    var accum = ordered.Aggregate(new Dictionary<DateTime, List<DateTime>>(), (dic, val) => {
        if (!dic.Any())
        {
            dic.Add(val, new List<DateTime> { val });
        }
        else
        {
            if ((val - dic.Values.Last().Last()).Days <= 1)
                dic.Values.Last().Add(val);
            else
                dic.Add(val, new List<DateTime> { val });
        }
        return dic;
    });
