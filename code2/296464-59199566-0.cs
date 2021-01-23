    public enum InputsOutputsBoth
    {
        Inputs,
        Outputs,
        Both
    }
    private IList<InputsOutputsBoth> _ioTypes = new List<InputsOutputsBoth>() 
    { 
        InputsOutputsBoth.Both, 
        InputsOutputsBoth.Inputs, 
        InputsOutputsBoth.Outputs 
    };
    public IEnumerable<InputsOutputsBoth> IoTypes
    {
        get { return _ioTypes; }
        set { }
    }
    private InputsOutputsBoth _selectedIoType;
    public InputsOutputsBoth SelectedIoType
    {
        get { return _selectedIoType; }
        set
        {
            _selectedIoType = value;
            OnPropertyChanged("SelectedIoType");
            OnSelectionChanged();
        }
    }
