    Employee.id++;
    Console.WriteLine($"Id: {Employee.id}");
    var emp2 = emp1; // both emp1 and emp2 have same values
    emp2.EmpId = 24;
    Console.WriteLine($"emp1.EmpId: {emp1.EmpId}");
    Console.WriteLine($"emp2.EmpId: {emp2.EmpId}");
