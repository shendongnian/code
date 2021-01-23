    public enum WorkType
    {
        Hourly = 1,
        Salary = 2,
        None = 3
    };
    // Initialize this to prevent craziness
    private WorkType employeeType = WorkType.None;
    public string EmployeeType
    {
        get
        {
            // I'm not sure why you want to return a string
            // in this property but whatevs.
            // First make sure that you have a valid enum
            if ((int)employeeType > 3 || (int)employeeType < 1)
                employeeType = WorkType.None;
            return employeeType.ToString();   // Don't need a switch, just call ToString()
            }
            set
            {
                // This might be better served with a TryParse. This will
                // be more fault tolerant if someone using your class passes
                // in an invalid WorkType.
                if(!TryParse(typeof(WorkType), value, out employeeType))
                    employeeType = WorkType.None;
            }
        }
    }
