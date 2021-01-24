    // gets the list of courses taken by the student id 
    public List<COURSES> GetCoursesByStudent(int pST_ROWID)
        {
            using (var con = new MPContext())
            {
                return con.COURSES.Include(x=>x.STUDENTS).
                                    Where(x => x.CR_SM_REFNO.Equals(pST_ROWID)).ToList();
            }
        }
        //Gets the list of students who get the course with the course id
        public List<STUDENTS> GetStudentsByCourse(int pCR_ROWID)
        {
            using (var con = new MPContext())
            {
                return con.STUDENTS.Include(x => x.COURSES).
                    Where(x => x.COURSES.Any(y=>y.CR_ROWID.Equals(pCR_ROWID))).ToList();
            }
        }
