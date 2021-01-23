    private PlayerClass playerClass;
    public PlayerClass SelectedClass
    {
      get { return playerClass; }
      set
      {
        if (playerClass != value)
        {
          playerClass = value;
          OnPropertyChanged(nameof(SelectedClass));
        }
      }
    }
