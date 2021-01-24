    public string Surname
    {
        get => return Employee.Surname;        
        set
        {
            string newValue = string.Empty;
            if (TryApplyPropertyChange(value, ref newValue))
            {
              // Because we cannot pass a property as a ref parameter
              Employee.Surname = newValue;
            }
        }
    }
