    public class ClassA
    {
      private ClassB c = new ClassB();
      
      public void someMethod()
      {
        lock (c.SyncRoot)
        {
          c.MyVar = 1;
          // Some other stuff
          c.MyVar = 0;
        }
      }
    }
    
    public class ClassB
    {
      private object m_LockObject = new object();
      private int m_MyVar;
    
      public object SyncRoot
      {
        get { return m_LockObject; }
      }
    
      public int MyVar
      {
        get
        {
          lock (SyncRoot)
          {
            return m_MyVar;
          }
        }
        set
        {
          lock (SyncRoot)
          {
            m_MyVar = value;
          }
        }
      }
    
      public void MethodA()
      {
        lock (SyncRoot)
        {
          if (m_MyVar == 1) m_Var = 0;
        }
      }
    }
