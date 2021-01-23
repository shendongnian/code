    protected void AddRelatedWebObject<A, B, O>(A mlaObject, B inputObject, List<Guid> guids) 
        where A : WebObject 
        where B : DbSet<O>
        where O : WebObject
    {
        foreach (Guid guid in guids)
        {
            mlaObject.RelatedWebObjects.Add(inputObject.Find(guid));
            _db.SaveChanges();
        }
    }
