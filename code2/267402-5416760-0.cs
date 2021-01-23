    [TestMethod]
    public void Test()
    {
        // ObjectQuery<Department> converted ot IEnumerable<Department>
        IEnumerable<Department> departmetns = CreateUnitOfWork().GetRepository<Department>().GetQuery();
        // No query execution here - Enumerable has also deffered exection
        var query = departmetns.Where(d => d.Id == 1); 
        // Queries ALL DEPARTMENTS here and executes First on the retrieved result set
        var result = departmetns.First(); 
    }
