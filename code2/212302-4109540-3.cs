    public static Chart PopulateInto<T>(List<T> yAxis, List<int> xAxis)
    {
        return PopulateInto<T, int>(yAxis, xAxis);
    }
    
    public static Chart PopulateInto<T>(List<T> yAxis, List<decimal> xAxis)
    {
        return PopulateInto<T, decimal>(yAxis, xAxis);
    }
    private static Chart PopulateInto<T, N>(List<T> yAxis, List<N> xAxis) where N : struct
    {
        // Do stuff here
    }
