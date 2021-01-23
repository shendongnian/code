    private ProfileCreateViewModel  _model;
    [Dependency]
    public ProfileCreateViewModel Model {
            set
            {
                _model = value;
                this.DataContext = _model;
            }
    }
