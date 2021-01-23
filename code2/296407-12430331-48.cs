    public IEnumerable<ValueDescription> PlayerClassList => EnumHelper.GetAllValuesAndDescriptions<PlayerClass>();
    private PlayerClass p_eClass;
    public PlayerClass SelectedClass
    {
      get { return p_eClass; }
      set
      {
        if (p_eClass != value)
        {
          p_eClass = value;
          OnPropertyChanged(nameof(SelectedClass));
        }
      }
    }
