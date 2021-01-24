    public List<YourEntityType> YourMethodName(Func<IQueryable<YourEntityType>, IOrderedQueryable<YourEntityType>> orderBy,IQueryable<YourEntityType> query=null)
    {
         query=query ?? GetYourEntityTypeList().AsQueryable();
         return orderBy(query).ToList();
    }
