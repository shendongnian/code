    public string ProfessorEmail
    {   
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged();
        }
    }
    public string ProfessorPhone
    {
        get => _phone;
        set
        {
            _phone = value;
            OnPropertyChanged();
        }
    }
