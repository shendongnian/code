    Func<Student, bool> predicate;
    predicate = s =>
        !string.IsNullOrEmpty(StudentNumber)
        ? s.StudentNumber.Equals(StudentNumber)
        : !string.IsNullOrEmpty(LastName)
            ? !string.IsNullOrEmpty(FirstName)
                ? s.LastName.Equals(LastName) && s.FirstName.Equals(FirstName)
                : s.LastName.Equals(LastName)
            : true;
    var query = Students.Where(predicate);
