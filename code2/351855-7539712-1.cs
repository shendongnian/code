    private int m_MyProperty;
    public int MyProperty
    {
       get
       {
          return m_MyProperty;
       }
       set
       {
          if(m_MyProperty != value)
          {
             m_MyProperty = value;
             RaisePropertyChanged("MyProperty");
           }
        }
    }
