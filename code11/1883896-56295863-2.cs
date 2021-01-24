    public Student Student
    {
        get { return _student; }
        set
        {
            if (value != _student)
            {
                if (_student != null)
                {
                    _student.PropertyChanged -= _student_PropertyChanged;
                }
                _student = value;
                if (_student != null)
                {
                    _student.PropertyChanged += _student_PropertyChanged;
                }
                OnPropertyChanged();
            }
        }
    }
    private void _student_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Title")
        {
            ClickSaveChangesCommand.RaiseCanExecuteChanged();
        }
    }
