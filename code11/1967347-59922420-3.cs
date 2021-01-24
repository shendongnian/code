    Employee.id = 2;
    
    // copy the values to var emp2
    var emp2 = emp1; // both emp1 and emp2 have same values
    // set emp2.EmpId to new value.
    emp2.EmpId = 24;
    Console.WriteLine($"Id: {Employee.id}");
    Console.WriteLine($"emp1.EmpId: {emp1.EmpId}");
    Console.WriteLine($"emp2.EmpId: {emp2.EmpId}");
