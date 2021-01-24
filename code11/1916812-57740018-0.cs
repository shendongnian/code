    public static IEnumerable<int> SequenceFindMissings(this IList<int> sequence)
    {
    
        var missing = new List<int>();
    
        if ((sequence != null) && (sequence.Any()))
        {
            sequence.Aggregate((seed, aggr) =>
                                {
                                    var diff = (aggr - seed) - 1;
    
                                    if (diff > 0)
                                        missing.AddRange(Enumerable.Range((aggr - diff), diff));
    
                                    return aggr;
                                });
        }
    
        return missing;
    }
