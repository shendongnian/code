    abstract class GridBase {
      public abstract object DataSource { get; }
    }
    
    class GenericGrid<T> : GridBase { 
      private T m_data;
    
      public override object DataSource { 
        get { return m_data; }
      }
      public T DataSourceTyped { 
        get { return m_data; }
        set { m_data = value; }
      }
    }
