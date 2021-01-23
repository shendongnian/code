      public delegate void ChangedEventHandler(object sender, EventArgs e);
 
      int m_i = 0;
      public int i 
      {
          get { return m_i; }
          set { m_i = value; iChanged(self, null); }
      }
      public ChangedEventHandler iChanged;
