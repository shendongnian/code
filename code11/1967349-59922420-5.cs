    Employee.id = 2;
    
    // copy emp1 values to var emp2
    var emp2 = emp1; // both emp1 and emp2 have same values
    // set emp2.EmpId to new value.
    emp2.EmpId = 24;
    Console.WriteLine("Id: {0}", Employee.id);
    Console.WriteLine("emp1.EmpId: {0}", emp1.EmpId);
    Console.WriteLine("emp2.EmpId: {0}", emp2.EmpId);
