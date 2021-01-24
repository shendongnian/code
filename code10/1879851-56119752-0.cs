    var contents = File.ReadAllLines(fileName);     // Load all lines into local array
    var employeeCount = contents.Length / 4;        // Figure out how many employees are there
    var employees = new EmployeeInfo[employeeCount];
    
    for (int i = 0; i < employeeCount; i++)
    {
        var offset = (i * 4);                       // Set a base offset based on the current empl.
        employees[i] = new EmployeeInfo
        {
            fname = contents.ElementAt(offset),
            lname = contents.ElementAt(offset + 1),
            empPay = Double.Parse(contents.ElementAt(offset + 2)),
            empType = contents.ElementAt(offset + 3),
        };
    }
