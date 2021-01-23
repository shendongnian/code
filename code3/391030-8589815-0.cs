      void CheckAndValidate()
      {
            this.ValidationFailures.Clear();
            int parse;
            if (!Int32.TryParse(
                  this.PatientAggRoot.Patient.Ssn, out parse))
            { 
                 this.ValidationFailures.Add(
                        new ValidationFailure("SSN", "Taj szám nem csak számokból áll"));
                 this.OnPropertyChanged("ValidationFailures");
            }
      } 
