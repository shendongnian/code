    public enum EmployeeType
    {
      Hourly = 1,
      Salary = 2,
      None = 3
    }
    private EmployeeType _EmployeeType;
    public EmployeeType EmployeeType
    {
      get { return this._EmployeeType; }
      set { this._EmployeeType = value; }
    }
