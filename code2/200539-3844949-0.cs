    private bool m_IsChanged = false;
    private double m_DoubleValue;
    
    //[...] all other private properties
    public double DoubleValue
    {
        get { return m_DoubleValue; }
        set
        {
           if(m_DoubleValue != value)
               m_IsChanged = true;
             
           m_DoubleValue = value;
        }
    }
    //[...] all other getters/setters
    public bool IsChanged
    {
       get { return m_IsChanged; }
    } 
