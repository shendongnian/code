    public string Registrationdate { 
        get; 
        set {
            DateTime date;
            var isDate = DateTime.TryParse(value, out date);
            if (isDate) { 
                _registrationDate = value; 
            }
            else {
              // Throw exception
            }
        }
    }
