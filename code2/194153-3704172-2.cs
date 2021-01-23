    class Select
    {
        public Guid Id { get { return ((ServiceResult)this).Id; } }
    }
    
    public Guid GetPropertyId(...) 
    { 
        return  
            Select 
            .Either(TryToGetTheId(...)) 
            .Or(TrySomethingElseToGetTheId(...)) 
            .Id; 
    }
