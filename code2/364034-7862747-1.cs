    var results = Students.AsEnumerable(); // use .AsQueryable() for EF or Linq-to-SQL
    
    if (!string.IsNullorEmpty(StudentNumber)) 
    {
        results = results.Where(s => s.StudentNumber.Equals(StudentNumber));
    }
    else if (!string.IsNullOrEmpty(LastName))
    {
        results = results.Where(s => s.LastName.Equals(LastName));
    
        if (!string.IsNullOrEmpty(FirstName))
             results = results.Where(s => s.FirstName.Equals(FirstName));
    }
    // results can be used here
