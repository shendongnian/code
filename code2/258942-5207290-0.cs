    // instead of below property in your BLL:
    
    private int m_someVariable;
    
    public int SomeVariable
    {
        get { return m_someVariable; }
        set { m_someVariable = value; }
    }
    
    // You can use the entity object:
    private readonly EntityClass _entityObject = new EntityClass();
    
    public int SomeVariable
    {
        get { return _entityObject.SomeVariable; }
        set { _entityObject.SomeVariable = value; }
    }
    
    // or make it read-only at your BLL
    
    public int SomeVariable
    {
        get { return entityObject.SomeVariable; }
        // set { entityObject.SomeVariable = value; }
    }
