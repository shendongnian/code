     public int Change
       {
          get { return m_change; }
          set
          {
             if (m_change != value)
             {
                m_change = value;
                ColumnWidth = WidthAlgo(numberOfCharacters);
                RaisePropertyChanged("Change");
                RaisePropertyChanged("ColumnWidth");
             }
          }
       }
