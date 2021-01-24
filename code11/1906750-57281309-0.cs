    public string TaskText
        {
            get
            {
                return _taskText;
            }
            set
            {
                if (_taskText != value)
                {
                    _taskText = value;
                    OnPropertyChanged();
                }
            }
        }
