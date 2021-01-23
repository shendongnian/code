    private Action<IEnumerable<string>, string, int> m_ProtectedMethod2 = null;
    private Action<IEnumerable<string>, string> m_ProtectedMethod = null;
    protected Action<IEnumerable<string>, string, int> ProtectedMethod
    {
       get { return m_ProtectedMethod2; }
       set {
          m_ProtectedMethod2 = value;
          m_ProtectedMethod = (p1,p2) => {
             m_ProtectedMethod2(p1,p2,1); //The value 1 is the default 3rd parameter
          }
       }
    }
    
    public MyMethod()
    {
       ...Do something  
       m_ProtectedMethod(param1, param2);  
       ...Do something  
       ...If something  
          m_ProtectedMethod2(param1, param2, param3); //Calling the more complex form directly
       ...Do something  
    }
