        // GET: api/Students
        public IQueryable<Student> GetStudent()
        {
            return db.Student;
        }
    To this:
        // GET: api/Students
        [ResponseType(typeof(StudentList))]
        public IHttpActionResult GetStudents()
        {
            StudentList studentList = new StudentList() 
            {
                Students = db.Student.ToList();
            }
            return Ok(studentList);
        }
