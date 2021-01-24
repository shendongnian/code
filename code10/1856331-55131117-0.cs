    Course testCourse = null;
    using (var context = new EntityContext())
    {
       testCourse = context.Courses.Single(x => x.CourseId == 3);
    }
    testCourse.Name = "UpdatedTest2";
    using (var context = new EntityContext())
    {
        context.Courses.Attach(testCourse);
        context.Entry(testCourse).State = EntityState.Modified;
        context.SaveChanges();
    }
