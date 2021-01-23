    IEnumerable<Course> courseInfos = null;
    foreach (Semester sm in semesters)
    {
        IList<CourseInstance> courseInstances = CourseInstance.Get(semesters[0].SemesterId);
        courseInfos = from c in courseInstances
                      select new Course { Code = c.Course.Code, Name = c.Course.Name };
    }
    return courseInfos.ToList();
