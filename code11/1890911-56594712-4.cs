      private ObservableCollection<WellenElement> m_WellenListe;
      public ObservableCollection<WellenElement> WellenListe
        {
          get { return m_WellenListe; }
          set
          {
            m_WellenListe = value;
            OnPropertyChanged("WellenListe");
          }
        }
