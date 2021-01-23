    public enum WorkType
    {
        Hourly = 1,
        Salary = 2,
        None = 3
    };
    public WorkType EmployeeType { get; set; }
    // Any time you want to access the value of EmployeeType as a string you would
    // simply use the following line:
    // EmployeeType.ToString();
