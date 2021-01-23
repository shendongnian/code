    class Grid : GridBase { 
      private objecm m_data;
      public override object DataSource {
        get { return m_data; }
      }
      public object DataSourceTyped {
        get { return m_data; }
        set { m_data = value; }
      }
    
    }
