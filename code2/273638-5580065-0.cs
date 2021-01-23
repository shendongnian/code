    public IEnumerable<IEnumerable<double>> GetRangesAboveLimit(IEnumerable<double> source, double limit)
    {
        //keep going until we've processed the entire range
        while (source.Any())
        {
            //skip elements below the limit
            source = source.SkipWhile(e => e <= limit);
            //yield the elements above the limit
            yield return source.TakeWhile(e => e > limit);
            //now skip those elements and then continue
            source = source.SkipWhile(e => e > limit);
        }
    }
