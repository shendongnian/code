    foreach (Employee item in MySelectedEmployee )
    {
       var currentEntry = listFromDB.FirstOrDefault( x => x.id == item.id);
       if(currentEntry == null || currentEntry.name!= item.name)
       {
         bool _flag = EmployeeService.SaveEmployee(item.Id, item.Name);
        ...
       }
    }
