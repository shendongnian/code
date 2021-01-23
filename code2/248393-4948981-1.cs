    public string Name 
    {
       get { return m_name; }
       set
       {
          if (value == null)
             throw new ArgumentNullException("value");
          
          m_name = value;
       }
    }
