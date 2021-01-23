      IEnumerable<Employee> collection = iQuaryable.AsEnumerable();
      List<Employee> myCollection = new List<Employee>();
      foreach(var emp in collection) 
      {
            if(string.IsNullOrEmpty(emp.LastName) || string.IsNullOrEmpty(emp.FirstName))
                 myCollection.Add(emp);
      }
