    public static IList<T> Bar<T>(this DataTable table)
       where T : IHasPostProcess
    {
       ...
       someT.postProcess();
       ...
    }
