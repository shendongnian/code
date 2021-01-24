    public class Student
        {
            public string StudentName { get; set; }
            public string StudentEmail { get; set; }
        }
       
        public StudRes<List<Student>> GetStudents()
        {
            Database SQLCon = new Database();
            DataTable dt = new DataTable();
    
            string query = @"select s.items StudentName from StudentData t1 outer apply dbo.Split(t1.StudentName, ',') s";
    
            dt = SQLCon.getDatatableFromSQL(query);
            
            var results = new StudRes<List<Student>>()
            {
                result = dt.Rows.Count,
                data = (from rw in dt.AsEnumerable()
                        select new Student
                        {
                            StudentName = rw["StudentName"].ToString(),
                        }).ToList()
            };
            foreach (var stu in results.data)
            {
                stu.StudentEmail = GetStudentInfor(stu.StudentName);
            }
            return results;
        }
     public ActionResult StudentCode()
            {
                StudAct _Act = new StudAct();
                var _Student = _Act.GetStudents();
                return View("Name of your view", _Student.ToList());
            }
