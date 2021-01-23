    var results = Students.AsEnumerable();
    
    if (!string.IsNullorEmpty(StudentNumber))
        results = results.Where(s => s.StudentNumber.Equals(StudentNumber));
    
    if (!string.IsNullOrEmpty(LastName))
        results = results.Where(s => s.LastName.Equals(LastName));
    
    if (!string.IsNullOrEmpty(FirstName))
        results = results.Where(s => s.FirstName.Equals(FirstName));
