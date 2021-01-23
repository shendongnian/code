    private ICommand m_isValidCheckCommand;
    public ICommand IsValidCheckCommand
    {
        get
        {
            return m_isValidCheckCommand ??
                (m_isValidCheckCommand = new RelayCommand(param => IsValidCheck()));
        }
    }
    private void IsValidCheck()
    {
        IsValid = CheckIsValid();
    }
    private bool CheckIsValid()
    {
        foreach (OptionViewModel option in Options)
        {
            if (option.IsChecked == true)
            {
                return true;
            }
        }
        return false;
    }
    private bool m_isValid;
    public bool IsValid
    {
        get { return m_isValid; }
        set
        {
            m_isValid = value;
            OnPropertyChanged("IsValid");
        }
    }
    public string this[string columnName]
    {
        get
        {
            if (columnName == "IsValid")
            {
                if (IsValid == false)
                {
                    return "At least 1 Option must be selected";
                }
            }
            return string.Empty;
        }
    }
