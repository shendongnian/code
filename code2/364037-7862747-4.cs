    Func<Student, bool> predicate;
    if (!string.IsNullOrEmpty(StudentNumber))
    {
        predicate = s => s.StudentNumber.Equals(StudentNumber);
    }
    else if (!string.IsNullOrEmpty(LastName))
    {
        predicate = s => s.LastName.Equals(LastName);
        if (!string.IsNullOrEmpty(FirstName))
        {
            Func<Student, bool> p = predicate;
            predicate = s => p(s) && s.FirstName.Equals(FirstName);
        }
    }
    else
    {
        predicate = s => true;
    }
    var query = Students.Where(predicate);
