    public Student Student
    {
        get { return _student; }
        set
        {
            if (value != _student)
            {
                if (_student != null)
                {
                    //  You do want to unhook this, otherwise there's a live reference 
                    //  to the old _student and it won't be free to be garbage collected. 
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
