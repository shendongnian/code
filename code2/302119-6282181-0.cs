    public static IQueryable<CLASSNAME> EXTENSIONNAME<TKey, TSource>(this IEnumerable<IGrouping<TKey, TSource>> source)
    {
      return from g in source
             select new CLASSNAME
             {
               PrintJobReportItem = new PrintJobReportItem
                                    {
                                      TotalPagesPrinted = g.Sum(p => p.PagesPrinted),
                                      AveragePagesPrinted = etc...,
                                      PercentOfSinglePagePrintJobs = etc...,
                                    },
               GROUPING = g
             };
    }
