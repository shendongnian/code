    class Project
    {
            public readonly Employee _Manager;
            public Employee Manager 
            {
                get { return _Manager; }
            }
    
            // ...
    
            //Initializes class-variables.
            public Project(Employee manager, EmployeeList 
                            employeeList)
            {
                _Manager = manager;
                // Manager = manager; //Error: Manageris read-only
            }
    }
