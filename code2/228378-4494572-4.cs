    //yield the first row of each group
    private static IEnumerable<DataRow> Sort(IEnumerable<IGrouping<string, DataRow>> groupByCollection)
    {
        //sort each character group(e.g. A,B) by integer part of their values
        var groupings =
            groupByCollection.Select(
                o =>
                new
                    {
                        o.Key,
                        Value = o.OrderBy(a => Regex.Replace(a["position"].ToString(), "[a-z]", "", RegexOptions.IgnoreCase)).ToArray()
                    }).ToArray();
    
        int i = 0, j;
        for (j = 0; j < groupings[i].Value.Length; j++,i=0)
            for (i = 0; i < groupings.Length; i++)
            {
                yield return groupings[i].Value[j];
            }
    }
