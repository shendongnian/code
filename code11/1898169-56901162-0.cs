    public IQueryable<Professors> GetCoursesWithAllStudents()
    {
         return db.Professors.Include(professor => professor.Courses)
                             .ThenInclude(course => course.Students);
    }
