    private RelayCommand _submitCommand;
    public ICommand SubmitCommand
    {
        get
        {
            if (_submitCommand == null)
            {
                _submitCommand = new RelayCommand(SubmitExecute, CanSubmitExecute, false);
            }
            return _submitCommand;
        }
    }
    private void SubmitExecute(object parameter)
    {
        Task.Id++;
        Tasks.Add(Task);
    }
    public string Content
    {
        get { return Task.Content; }
        set
        {
            Task.Content = value;
            if (string.IsNullOrEmpty(Task.Content))
                _validationErrors[nameof(Content)] = "Field is required";
            else
                _validationErrors.Remove(nameof(Content));
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Content)));
            _submitCommand.RaiseCanExecuteChanged();
        }
    }
    private bool CanSubmitExecute(object parameter)
    {
        return HasErrors;
    }
    #region INotifyDataErrorInfo
    private readonly Dictionary<string, string> _validationErrors = new Dictionary<string, string>();
    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    public System.Collections.IEnumerable GetErrors(string propertyName)
    {
        if (string.IsNullOrEmpty(propertyName)
            || !_validationErrors.ContainsKey(propertyName))
            return null;
        return new string[1] { _validationErrors[propertyName] };
    }
    public bool HasErrors
    {
        get { return _validationErrors.Count > 0; }
    }
    #endregion
