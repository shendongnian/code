    public string Registrationdate { 
        get; 
        set {
            DateTime date;
            var isDate = DateTime.TryParse(value, date);
            if (isDate) { 
                _registrationDate = value; 
            }
            else {
              // Throw exception
            }
        }
    }
