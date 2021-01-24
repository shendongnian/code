    Course testCourse = null;
    var openContext = new EntityContext();
    testCourse = openContext.Courses.Single(x => x.CourseId == 3);
    openContext.Entry(testCourse).State = EntityState.Detached; // Remove association from original context.
    testCourse.Name = "UpdatedTest2";
    
    using (var context = new EntityContext())
    {
        context.Courses.Attach(testCourse);
        context.Entry(testCourse).State = EntityState.Modified;
        context.SaveChanges();
    }
