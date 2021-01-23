    public IList<MyObject> GetPageOfMyObjects(int pageSize, int zeroBasedPageNumber){
        return Session.CreateCriteria(typeof (MyObject))
                        .SetFirstResult(pageSize*(pageNumber))
                        .SetMaxResults(pageSize)
                        .List<MyObject>();
    
    }
