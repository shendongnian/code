    // Create a new entity object manually assigning each value
    // from the first object to the value in the new object.
    var clonedStudent = new Student
    {
        Id = john.Id, // Copies value not reference
        LastName = john.LastName, // string is immutable this OK
        FirstName = john.FirstName, // string is immutable this OK
        // DateTime is a struct I think so it should pass value
        EnrollmentDate = john.EnrollmentDate, // Verify my assumption
        /* If you are changing navigational properties you need to clone them
         * or the same thing can happen. */
        Enrollments = john.Enrollments.Select(enrollment => enrollment.Clone());
    };
