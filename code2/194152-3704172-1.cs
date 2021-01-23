    class Select
    {
        public ServiceResult AsServiceResult()
        {
            return (ServiceResult)this;
        }
    }
    
    public Guid GetPropertyId(...) 
    { 
        return  
            Select 
            .Either(TryToGetTheId(...)) 
            .Or(TrySomethingElseToGetTheId(...)) 
            .AsServiceResult()
            .Id; 
    } 
