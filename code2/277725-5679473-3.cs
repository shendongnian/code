    public String EmployeeType()
    {
      switch (this._EmployeeType)
      {
        case EmployeeType.Hourly:
          return "Hourly Employee";
        case EmployeeType.Salary:
          return "Salary Employee";
        default:
          return "None";
      }
    }
