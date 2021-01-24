    void ChangeStudent(int studentId, Address address, int schoolId)
    {
        using (var dbContext = new SchoolDbContext())
        {
            ChangeAddress(dbContext, studentId, address);
            ChangeSchool(dbContext, studentId, schoolId);
            dbContext.SaveChanges();
        }
    }
