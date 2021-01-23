      public List<Course> GetCourse()
            {
            IList<Semester> semesters = Semester.Get();
            List<Course> courseInfos = new List<Course>();
            foreach (Semester sm in semesters)
                {
                IList<CourseInstance> courseInstances = CourseInstance.Get(sm.SemesterId);
                IEnumerable<Course> result = from c in courseInstances
                                  select new Course { Code = c.Course.Code , Name = c.Course.Name };
                courseInfos.AddRange(result);
                }
            return courseInfos;
            }
