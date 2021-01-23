    public ObservableCollection<CustomVariable> CustomVariables
    {
        get
        {
            if (this._customVariables == null)
            {
                this._customVariables = new ObservableCollection<CustomVariable>();
            }
            return this._customVariables;
        }
        private set
        {
            this._customVariables = value;
        }
    }
