    public void ProcessImportObjects<TSource, TDestination>
        (Action<TDestination, ImportDataSource, int> processMethod,
         Func<DataContext, IEnumerable<TSource>> dcProperty
         ImportDataSource importSource,
         int resultId)
    {
        using (DataContext dc = new DataContext())
        {
            dc.ObjectTrackingEnabled = false;
            Mapper.CreateMap<TSource, TDestination>();
            foreach (TSource d in dcProperty(dc))
            {
                TDestination doc = Mapper.Map<TSource, TDestination>(d);
                processMethod(doc, importSource, resultId);
            }
        }
    }
