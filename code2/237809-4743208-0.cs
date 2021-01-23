    [OperationContract]     
    public List<Depts> GetAll()
    {        
        GearsLtdEntities ge = new GearsLtdEntities();        
        return ge.Depts.Include("Employees").ToList();
    }
