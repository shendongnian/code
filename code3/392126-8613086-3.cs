    public void ModifyPerson(Person person)
    {
      var currentEmployer = DAL.Employers.Get(Person.Employer.EmployerID);
      if (currentEmployer != person.Employer)
      {
        // Try and get a matching Employer from the appropriate Service (liaising with the DAL)
        var employer = EmployerManager.GetEmployer(person.Employer.EmployerID);
        if (employer == null)
        {
          // ... Create a new employer
        }
        else if (employer != person.Employer)
        {
          // ... Update existing employer
        }
      }
    
      // ... Now go ahead and handle any changes to the person
    }
