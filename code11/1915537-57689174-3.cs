    public int CountCourseStudents(int courseId) {
       var courseStudents = context.Students
                       .Where(student => student.Courses
                              .Any(course => course.Id == courseId));
       return courseStudents.Count();  
    }
