    public static List<double> GetPositions(this List<CandyPositions> positions,
                                            Func<CandyPositions, double> projection)
    {
        return positions.Select(projection).ToList();
    }
