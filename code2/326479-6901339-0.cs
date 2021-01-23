    public List<Course> GetCourse()
    {
        List<Course> courseInfos = new List<Course>();
        IList<Semester> semesters = Semester.Get();     
        foreach (Semester sm in semesters)
        {
            IList<CourseInstance> courseInstances = CourseInstance.Get(semesters[0].SemesterId);
            var ci = from c in courseInstances
                                  select new Course { Code = c.Course.Code, Name = c.Course.Name };
            courseInfos.AddRange(ci);
        }
        return courseInfos;
    }
