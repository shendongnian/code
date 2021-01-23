    MyDictionary.Add(new Employee() { EmployeeID = 1, PayID = 1 });
     MyDictionary.Add(new Employee() { EmployeeID = 1, PayID = 2 });
     MyDictionary.Add(new Employee() { EmployeeID = 2, PayID = 3 });
     MyDictionary.Add(new Employee() { EmployeeID = 3, PayID = 1 });
    
     foreach (Employee e in MyDictionary.GetEmps(1))
        Console.WriteLine(e.EmployeeID + " " + e.PayID);  
 
