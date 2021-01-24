    public Courses_Model GetCourses(string id)
    { 
        Course= con.Courses.Include(x => x.Students)
                .Where(g => g.REQUESTER_REFERENCE == id)
                .Select(
                      g => new Courses_Model
                               {
                                    courseid = g.courseid,
                                    Students = g.Students.Select(x => new Student_Model { id = x.id, Name = x.Name })
                               })
                .First();
    
        return course;
    }
