    public string Surname
    {
        get => return Employee.Surname;        
        set
        {
            string newValue = string.Empty;
            if (TryApplyPropertyChange(value, ref newValue))
            {
              Employee.Surname = newValue;
            }
        }
    }
