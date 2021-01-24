    // Private parameterized CTOR
    private Element( int id, string code ) 
    { 
        this.Id = id;
        this.Code = code;
    }
    
    // Simplyfied Clone
    public object Clone()
    {
        return new Element(Id, Code);
    }
