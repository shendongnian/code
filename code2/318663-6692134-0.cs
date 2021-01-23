    public Count
    {
    get {return m_Count;}
     set { m_Count=value;
          GetCurrentPropertyNameUsingReflectionAndNotifyItChanged();}
    }
