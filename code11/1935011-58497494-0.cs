    public string _courseTitle;
    public string CourseTitle
    {
        get => _courseTitle;
        set
        {
            _courseTitle = value;
            RaisePropertyChanged(nameof(CourseTitle));
        }
    }
