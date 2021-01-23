    public Employee
    {
        int Age { get; set; }
        string Name { get; set;}
        Employee Self
        {
            get { return this; }
        }
    } 
