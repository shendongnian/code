    public static Task<IEnumerable<Journey>> QueryJourneys(Point from, Point to,
                                                           DateTime lastStart)
    {
        string str = cs_requestResultPage(from, to, lastStart);
        return d2(str);
    }
